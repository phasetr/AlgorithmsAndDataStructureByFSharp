// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_B/review/2403060/anndonut/JavaScript
// Strategy
//
//  - the function Array.indexOf is very high speed.
//  - in the case of T.length=max, P.length=max and
//    "high correlation", the speed of Array.indexOf is decreasing.
//  - therefore, we prepare the process for "high correlation" in first.

//config = { input: 'tmp', newline: '\r\n' }; // win
config = { input: '/dev/stdin', newline: '\n' }; // linux

line = require('fs').readFileSync(config.input, 'ascii').split(config.newline, 2);

T = line[0];
P = line[1];
line = null;
P2 = P + P;
for (cor = 0; cor < P.length && P2.indexOf(P, cor) === cor; cor++) ;
cor--;

if (cor < 10) normal_search();
else search_with_correlation_check();

function normal_search() {
  var res, idx, j;
  res = new Array(T.length);
  idx = 0;
  j = 0;
  while ((idx = T.indexOf(P, idx)|0) !== -1) {
    res[j] = idx;
    idx = (idx + 1)|0;
    j = (j + 1)|0;
  }

  res.length = j;
  if (res.length !== 0) console.log(res.join('\n'));
}

function search_with_correlation_check() {
  var res, idx, j, k;
  res = new Array(T.length);
  idx = 0;
  j = 0;
  while ((idx = T.indexOf(P, idx)|0) !== -1) {
    if (T.indexOf(P2, idx) === idx) {
      for (k = 0; k <= cor; k = (k+1)|0) {
        res[j] = idx;
        idx = (idx + 1)|0;
        j = (j + 1)|0;
      }
    } else {
      res[j] = idx;
      idx = (idx + 1)|0;
      j = (j + 1)|0;
    }
  }

  res.length = j;
  if (res.length !== 0) console.log(res.join('\n'));
}
