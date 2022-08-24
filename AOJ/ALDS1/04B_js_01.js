// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_B/review/2258596/ant2357/JavaScript
const binarySearch = function(key, n, a) {
  const left = 0;
  const right = n;
  while (left < right) {
    const mid = Math.floor((left + right) / 2);
    if (a[mid] == key) {
      return true;
    } else if (key < a[mid]) {
      right = mid;
    } else {
      left = mid + 1;
    }
  }

  return false;
};

(function(stdin) {
  const arr = (stdin.trim()).split('\n');
  const s = arr[1].split(" ").map(Number);
  const t = arr[3].split(" ").map(Number);

  const ans = 0;
  for (let i = 0; i < t.length; i++) {
    ans += binarySearch(t[i], s.length, s);
  }
  console.log(ans);
})(require('fs').readFileSync('/dev/stdin', 'utf8'));
