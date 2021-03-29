namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Linq;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(x => ids.Contains(x.Id))
                .Select(x => new PrisonerOutputModel
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers
                        .Select(x => new OfficerPrisonerOutputModel
                        {
                            OfficerName = x.Officer.FullName,
                            Department = x.Officer.Department.Name,
                        })
                        .OrderBy(x => x.OfficerName)
                        .ToList(),
                    TotalOfficerSalary = decimal.Parse(x.PrisonerOfficers
                        .Sum(x => x.Officer.Salary)
                        .ToString("f2")),
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToList();

            string jsonOutput = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return jsonOutput;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var names = prisonersNames.Split(',', StringSplitOptions.RemoveEmptyEntries);

            var prisoners = context.Prisoners
                .Where(x => names.Contains(x.FullName))
                .Select(p => new PrisonerViewModel
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = p.Mails
                        .Select(m => new EncryptetMessageViewModel
                        {
                            Description = string.Join("", m.Description.Reverse()),
                            
                        })
                        .ToArray()
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToList();

            var xmlResult = XmlConverter.Serialize(prisoners, "Prisoners");

            return xmlResult;
        }
    }
}