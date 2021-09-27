function solve() {
  let text = document.getElementById('text').value;
  let namingConvention = document.getElementById('naming-convention').value;
  let wordsArr = text.split(' ').map(a => a.toLowerCase());
  let result = [];

  if (namingConvention === 'Pascal Case'){
      result = wordsArr.map(currWord => {
          return currWord.charAt(0).toUpperCase() + currWord.slice(1);
      });
  } else if (namingConvention === 'Camel Case'){
      result = wordsArr.map((currWord, i) => {
          if (i !== 0){
              return currWord.charAt(0).toUpperCase() + currWord.slice(1);
          }
          return currWord;
      });
  } else{
      result.push('Error!');
  }

  document.getElementById('result').textContent = result.join('');
}