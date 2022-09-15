// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_B/review/2720776/enoyo/JavaScript
process.stdin.resume();
process.stdin.setEncoding("utf8");
let input = "";
process.stdin.on("data", function(chunk) {input += chunk;});
process.stdin.on("end", function() {main(input.split("\n"));});

let time = 0;

function allocNode(u,k) {
  const p = {};
  p.value = u;
  p.forward = 0;
  p.backward = 0;
  p.chldNum = k;
  p.children = k > 0 ? [] : null;
  return p;
}

function dfs(nodes,u) {
  let i;
  const p = nodes[u];
  if (p.forward > 0) return;
  p.forward = ++time;
  for (i = 0; i < p.chldNum; i++) {dfs(nodes,p.children[i]);}
  p.backward = ++time;
}

function main(lines){
  const n = Number(lines[0]);
  const nodes = [];
  let i, j , u, k, line;
  for (i = 0; i < n; i++) {
    line = lines[1 + i].split(" ").map(Number);
    u = line[0];
    k = line[1];
    nodes[i] = allocNode(u,k);
    for (j = 0; j < k; j++)
      nodes[i].children[j] = line[2 + j] - 1;
  }

  for (i = 0; i < n; i++) {
    if (nodes[i].forward === 0) {dfs(nodes,i);}
  }
  for (i = 0; i < n; i++) {
    console.log(`${nodes[i].value} ${nodes[i].forward} ${nodes[i].backward}`);
  }
}
