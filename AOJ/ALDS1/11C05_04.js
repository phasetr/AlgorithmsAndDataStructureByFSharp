// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_C/review/6302172/sara3wati_3333/JavaScript
var input = require('fs').readFileSync('/dev/stdin', 'utf8');
var lines = (input.trim()).split("\n");

var n = parseInt(lines[0]);
var d = [];
var list = {};
d[0] = null;
d[1] = 0;

for (var i = 1; i <= n; i++) {
    var t = lines[i].split(" ")
                    .map(Number);
    var u = t.shift(),
        k = t.shift();
        if (k !== 0) list[u] = t;
        else list[u] = [];
}

for (var i = 2; i <= n; i++) {
    d[i] = -1;
}
var q = list[1];
var nq = [];
var count = 1;
while (q.length > 0) {
    var p = q.shift();
    if (d[p] === -1) {
        d[p] = count;
        nq = nq.concat(list[p]);
    }
    if (q.length === 0) {
        count++;
        q = Array.from(nq);
        nq = [];
    }
}
for (var i = 1; i <= n; i++) {
    console.log(`${i} ${d[i]}`);
}
