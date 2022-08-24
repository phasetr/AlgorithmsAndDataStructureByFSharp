// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_C/review/2690973/napo/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8'); 
const xs = input.trim().split('\n').slice(1).map(function(x){ return x.split(' '); }); 
const ys = {};
xs.forEach(function(x){
  if(x[0] === 'insert'){
    ys[x[1]] = true;
  }else if(x[0] === 'find'){
    console.log(ys.hasOwnProperty(x[1]) ? 'yes' : 'no');
  }
});
