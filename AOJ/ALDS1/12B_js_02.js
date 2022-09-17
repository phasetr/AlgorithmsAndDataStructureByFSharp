// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_B/review/2521074/anndonut/JavaScript
//config = { input: 'tmp', newline: '\r\n' }; // win
config = { input: '/dev/stdin', newline: '\n' }; // linux

line = require('fs').readFileSync(config.input, 'ascii').trim().split(config.newline);
n = Number(line.shift());
adj = {};
function add(obj, u, v, c) {
  if (!obj.hasOwnProperty(u)) obj[u] = {};
  obj[u][v] = c;
}
for (i in line) {
  ary = line[i].split(' ').map(Number);
  u = ary[0];
  for (j = 2; j < ary.length; j += 2)
    add(adj, u, ary[j], ary[j+1]);
}

d = new Array(n);
pi = new Array(n);

function initializeSingleSource(s) {
  var i;
  for (i = 0; i < n; i++) {
    d[i] = Number.POSITIVE_INFINITY;
    pi[i] = null;
  }
  d[s] = 0;
}

function relax(u, v, w) {
  if (d[v] > d[u] + w) {
    d[v] = d[u] + w;
    pi[v] = u;
  }
}

function bellmanFord(adj, s) {
  initializeSingleSource(s);
  for (i = 1; i < n; i++) {
    for (u in adj) {
      for (v in adj[u]) {
        relax(u, v, adj[u][v]);
      }
    }
  }
  for (u in adj) {
    for (v in adj[v]) {
      if (d[v] > d[u] + adj[u][v])
        return false;
    }
  }
  return true;
}

bellmanFord(adj, 0);
for (i in d) console.log("%s %d", i, d[i]);
