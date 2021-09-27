function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let dataElementsArr = Array.from(document.getElementsByTagName('tbody')[0].children);

      for (const row of dataElementsArr) {
         row.classList.remove('select');
      }

      let searchTerm = document.getElementById('searchField').value;

      for (let row of dataElementsArr) {
         for (const studentData of row.getElementsByTagName('td')) {
            if (studentData.textContent.includes(searchTerm)){
               row.classList.add('select');
               break;
            }
         }
      }
   }
}