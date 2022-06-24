// https://onlinejudge.u-aizu.ac.jp/problems/ALDS1_11_D
// TLEしてしまう
function solve(lines) {
  const [n,m] = lines.shift().split(' ').map(Number);
  const nodes = [];
  const color = [];

  for (let i=0; i<n; i++) {
    nodes.push([]);
    color.push(null);
  }

  for (let i=0; i<m; i++) {
    const node = lines.shift().split(' ').map(Number);
    nodes[node[0]].push(node[1]);
    nodes[node[1]].push(node[0]);
  }

  function dfs(n, id) {
    const stack = [];
    color[n] = id;
    stack.push(n);
    while (stack.length > 0) {
      const next = stack.shift();
      for (let i=0; i<nodes[next].length; i++) {
        if (!color[nodes[next][i]]) {
          color[nodes[next][i]] = id;
          stack.push(nodes[next][i]);
        }
      }
    }
  }

  let id = 1;
  for (let i=0; i<n; i++) {
    if (!color[i]) { dfs(i, id++); }
  }

  const q = parseInt(lines.shift(), 10);
  const answer = [];
  lines.forEach((relation) => {
    const [i,j] = relation.split(' ').map(Number);
    answer.push(color[i] === color[j] ? "yes" : "no");
  });
  return answer;
}
((stdin) => {
  const lines = require('fs').readFileSync('/dev/stdin', 'utf8').trim().split("\n");
  solve(stdin).forEach(s => console.log(s));
})();

function compare(xa,ya) { return JSON.stringify(xa) === JSON.stringify(ya); }
console.log(compare(solve(["10 9","0 1","0 2","3 4","5 7","5 6","6 7","6 8","7 8","8 9","3","0 1","5 9","1 3"]),["yes","yes","no"]));
