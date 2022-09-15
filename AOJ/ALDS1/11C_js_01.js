// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_C/review/950132/mihchang/JavaScript
var input = require('fs').readFileSync('/dev/stdin', 'utf8').trim();
var lines = input.split('\n');

var n = +lines.shift();

var g = [[]];
for (var i = 1; i <= n; i++) {
    g.push([]);
    for (var j = 1; j <= n; j++) {
        g[i][j] = 0;
    }
}

for (var i = 1; i <= n; i++) {
    var u = lines.shift().split(' ').map(function(n){return +n;});
    var id = u[0];
    var k = u[1];

    for (var j = 0; j < k; j++) {
        g[i][u[2 + j]] = 1;
    }
}

var d = [];
for (var i = 0; i <= n; i++) {
    d[i] = -1;
}
var Q = [1];
d[1] = 0;
var u;
while (u = Q.shift()) {
    for (var i = 1; i <= n; i++) {
        if (!g[u][i]) continue;

        var v = i;
        if (d[v] == -1) {
            d[v] = d[u] + 1;
            Q.push(v);
        }
    }
}

for (var id = 1; id <= n; id++) {
    console.log(id, d[id]);
}
