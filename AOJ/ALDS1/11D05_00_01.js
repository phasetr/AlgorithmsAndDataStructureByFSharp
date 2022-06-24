// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_D/review/1727342/hipokaba/JavaScript
// TLE
const p = [];
const r = [];
function find(i) { return p[i] === i ? i : p[i] = find(p[i]); }
function same(i,j) { return find(i) === find(j); }

process.stdin.resume();
process.stdin.setEncoding('utf8');

let lines = [];
let reader = require("readline").createInterface({
  input: process.stdin,
  output: process.stdout,
  terminal: false
});
reader.on("line", (line) => {
  lines.push(line);
});
reader.on("close", () => {
  main(lines);
});

function main(){
  const [n,m] = lines.shift().split(" ").map(Number);
  for (let i=0; i<n; i++) {
    p[i] = i;
    r[i] = 0;
  }

  for (let i=0; i<m; i++) {
    const [j,k] = lines.shift().split(" ").map(Number);
    let a = find(j);
    let b = find(k);

    if(a === b){ continue; }

    if(r[a] > r[b]){ p[b] = a; }
    else{
      p[a] = b;
      if(r[a] === r[b]){ ++r[b]; }
    }
  }

  const q = Number(lines.shift());
  for (let i=0; i<q; i++) {
    const [j,k] = lines.shift().split(" ").map(Number);
    console.log(same(j,k) ? 'yes' : 'no');
  }
}
