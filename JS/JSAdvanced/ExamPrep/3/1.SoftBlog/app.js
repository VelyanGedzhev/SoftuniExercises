function solve(){
   document.getElementsByClassName('btn create')[0]
       .addEventListener('click', addPost);
  const section = document.querySelector('.site-content section');
  const archives = document.querySelector('.archive-section ol');

   function addPost(ev) {
     ev.preventDefault();
     const form = ev.target.parentElement;
     const inputs = Array.from(form.querySelectorAll('input'));
     inputs.push(form.querySelector('#content'));

     const author = inputs[0].value;
     const title = inputs[1].value;
     const category = inputs[2].value;
     const content = inputs[3].value;

     const deleteBtn = createStructure('button', ['btn', 'delete'], 'Delete');
     const archiveBtn = createStructure('button', ['btn', 'archive'], 'Archive');
       archiveBtn.addEventListener('click', archivePost.bind(null, title));
       deleteBtn.addEventListener('click', removePost);

     const article = createStructure('article', [],
         createStructure('h1', [], title),
         createStructure('p', [], 'Category:',
             createStructure('strong', [], category)),
         createStructure('p', [], 'Creator:',
             createStructure('strong', [], author)),
         createStructure('p', [], content),
         createStructure('div', ['buttons'],
             deleteBtn,
             archiveBtn
         )
     );
     section.appendChild(article);
     inputs.forEach(i => i.value = '');
   }

   function createStructure(type, classes, ...content) {
     const element = document.createElement(type);

       for (const className of classes) {
           element.classList.add(className);
       }

     for (let item of content) {
       if (typeof item === 'string') {
         item = document.createTextNode(item);
       }

       element.appendChild(item);
     }

     return element;
   }

    function archivePost(title, ev) {
        const article = ev.target.parentElement.parentElement;
        article.remove();
        const li = createStructure('li', [], title);
        archives.appendChild(li);
        const sortedChildren = Array.from(archives.children)
            .sort((a, b) => a.textContent.localeCompare(b.textContent));
        sortedChildren.forEach(c => archives.appendChild(c));
    }

    function removePost(ev) {
        const article = ev.target.parentElement.parentElement;
        article.remove();
    }
  }
