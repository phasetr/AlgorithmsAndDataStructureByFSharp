// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_D/review/3693376/takumi_yamamoto/JavaScript
function solve(arr, len) {
  let ans = 0;
  const V = [];
  const sorted = [];
  const mapTable = [];
  const min = Math.min(...arr);

  for (let i = 0; i < len; i++) {
    sorted[i] = arr[i];
    V[i] = false;
  }

  sorted.sort((a, b) => a - b);

  for (let i = 0; i < len; i++) {
    mapTable[sorted[i]] = i;
  }
  for (let i = 0; i < len; i++) {
    if (V[i]) continue;
    let cur = i;
    let s = 0;
    let m = 10000;
    let an = 0;
    while (1) {
      V[cur] = true;
      an++;
      let v = arr[cur];
      m = Math.min(m, v);
      s += v;
      cur = mapTable[v];
      if (V[cur]) break;
    }
    ans += Math.min(s + (an - 2) * m, m + s + (an + 1) * min);
  }

  return ans;
}
function main(_stdin) {
  const stdin = _stdin.split('\n');
  const len = parseInt(stdin.shift(), 10);
  const seq = stdin.shift().split(' ').map(e => parseInt(e, 10));

  const ans = solve(seq, len);
  console.log(ans);
}

main(require('fs').readFileSync('/dev/stdin', 'utf8'));
