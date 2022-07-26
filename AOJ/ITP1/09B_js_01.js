// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_B/review/1220432/miraikako/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const Arr = (input.trim()).split("\n");
for (let i=0; i<Arr.length; i++){
  if (Arr[i]==="-") {break;}
  let str = Arr[i];
  let next = Arr[i+1]-0;
  for(let j=0; j<next; j++){
    const num = Arr[i+2+j]-0;
    str = str.slice(num)+str.slice(0,num);
  }
  i = i+next+1;
  console.log(str);
}
