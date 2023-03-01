// https://atcoder.jp/contests/tessoku-book/submissions/36545518
class SegmentTree {
  constructor() {
    this.dat = new Array(600000);
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
      this.dat[pos] = this.dat[pos*2] + this.dat[pos * 2 + 1];
    }
  }
  query(l, r, a, b, u) {
    if (r <= a || b <= l) return 0;
    if (l <= a && b <= r) return this.dat[u];
    let m = Math.floor((a + b) / 2);
    let ansL = this.query(l, r, a, m, u * 2);
    let ansR = this.query(l, r, m, b, u * 2 + 1);
    return ansL + ansR;
  }
}

function main(input) {
  input = input.trim().split('\n');
  let n = parseInt(input[0]);
  let a = input[1].split(' ').map(val => parseInt(val));

  let st = new SegmentTree();
  st.init(n);
  let ans = 0;
  for (let i = 0; i < n; i++) {
    ans += st.query(a[i]+1, n+1, 1, st.siz+1, 1);
    st.update(a[i], 1);
  }
  console.log(ans);
}
main(require("fs").readFileSync("/dev/stdin", "utf8"));
