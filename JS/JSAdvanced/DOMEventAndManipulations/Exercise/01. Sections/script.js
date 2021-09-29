function create(words) {
   const content = document.getElementById('content');
   content.addEventListener('click', reveal);

   for (let word of words) {
      const div = document.createElement('div');
      const paragraph = document.createElement('p');

      paragraph.textContent = word;
      paragraph.style.display = 'none';

      div.appendChild(paragraph);
      content.appendChild(div);
   }

   function reveal(e) {

      if (e.target.tagName == 'DIV' && e.target != content) {
         e.target.children[0].style.display = '';
      }
      
   }
}