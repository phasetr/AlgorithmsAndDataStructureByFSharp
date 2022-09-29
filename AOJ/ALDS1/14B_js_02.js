// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_B/review/6271600/sara3wati_3333/JavaScript
var input = require('fs').readFileSync('/dev/stdin', 'utf8');
var lines = (input.trim()).split("\n");

T = lines[0];
P = lines[1];
lines = null;
P2 = P + P;
for (cor = 0; cor < P.length && P2.indexOf(P, cor) === cor; cor++) ;

if (cor < 10) normal_search();
else search_with_correlation_check();

function normal_search() {
  var res, idx, j;
  res = new Array(T.length);
  idx = 0;
  j = 0;
  while ((idx = T.indexOf(P, idx)) !== -1) {
    res[j] = idx;
    idx = (idx + 1);
    j = (j + 1);
  }

  res.length = j;
  if (res.length !== 0) console.log(res.join('\n'));
}

function search_with_correlation_check() {
  var res, idx, j, k;
  res = new Array(T.length);
  idx = 0;
  j = 0;
  while ((idx = T.indexOf(P, idx)) !== -1) {
    if (T.indexOf(P2, idx) === idx) {
      for (k = 0; k <= cor; k = (k+1)) {
        res[j] = idx;
        idx = (idx + 1);
        j = (j + 1);
      }
    } else {
      res[j] = idx;
      idx = (idx + 1);
      j = (j + 1);
    }
  }

  res.length = j;
  if (res.length !== 0) console.log(res.join('\n'));
}
