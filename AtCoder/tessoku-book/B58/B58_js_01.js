// https://atcoder.jp/contests/tessoku-book/submissions/36532298
class SegmentTree {
  constructor() {
    this.dat = new Array(300000);
    this.siz = 1;
  }
  init(n) {
    this.siz = 1;
    while (this.siz < n) {
      this.siz *= 2;
    }
    for (let i = 1; i < this.siz * 2; i++) {
      this.dat[i] = 0;
    }
  }
  update(pos, x) {
    pos = pos + this.siz - 1;
    this.dat[pos] = x;
    while (pos >= 2) {
      pos = Math.floor(pos / 2);
      this.dat[pos] = Math.min(this.dat[pos*2], this.dat[pos * 2 + 1]);
    }
  }
  query(l, r, a, b, u) {
    if (r <= a || b <= l) return 1000000000;
    if (l <= a && b <= r) return this.dat[u];
    let m = Math.floor((a + b) / 2);
    let ansL = this.query(l, r, a, m, u * 2);
    let ansR = this.query(l, r, m, b, u * 2 + 1);
    return Math.min(ansL, ansR);
  }
}

function lowerBound(array, x) {
  let left = 0;
  let right = array.length - 1;
  while (left <= right) {
    let c = Math.floor((left + right) / 2);
    if (x > array[c]) {
      left = c + 1;
    } else {
      right = c - 1;
    }
  }
  return left;
}

function main(input) {
  input = input.trim().split('\n');
  let [n,l,r] = input[0].split(' ').map(val => parseInt(val));
  let x = input[1].split(' ').map(val => parseInt(val));

  let st = new SegmentTree();
  let dp = new Array(100009).fill(0);
  st.init(n);
  dp[1] = 0;
  for (let i = 2; i <= n; i++) {
    let posL = lowerBound(x, x[i-1]-r) + 1;
    let posR = lowerBound(x, x[i-1]-l+1);
    dp[i] = st.query(posL, posR+1, 1, st.siz+1, 1) + 1;
    st.update(i, dp[i]);
  }
  console.log(dp[n]);
}
main(require("fs").readFileSync("/dev/stdin", "utf8"));
