function search() {
   const elements = Array.from(document.querySelectorAll('ul li'));
   const text = document.getElementById('searchText').value;
   const result = document.getElementById('result');
   let matchCount = 0;

   elements.forEach((el) => {
      if (el.innerHTML.includes(text)){
         el.style.fontWeight = 'bold';
         el.style.textDecoration = 'underline';
         matchCount++;
      } else {
         el.style.fontWeight = 'normal';
         el.style.textDecoration = '';
      }
   })

   result.textContent = `${matchCount} matches found`;
}
