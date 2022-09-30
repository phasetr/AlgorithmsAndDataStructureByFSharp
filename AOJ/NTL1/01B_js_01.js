// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_B/review/4752225/KazukiM/JavaScript
function Main(input) {
  input = input.trim().split("\n").map(function(x) { return x.split(" "); });
  let m = parseInt(input[0][0], 10);
  let n = parseInt(input[0][1], 10);
  let C = 1e9 + 7;
  let C2 = 1e5 * 5;
  console.log(fastRuijoR(m, n, C, C2));
}

function fastRuijoR(a, b, C, C2){
  var ans = 1;
  var binary = b.toString(2);
  var l = binary.length;
  var tmp = a;
  for (var i = 0; i < l; i++){
    if (binary.substr((i + 1) * -1, 1) === '1') ans = kakeruR(ans, tmp, C, C2);
    tmp = kakeruR(tmp, tmp, C, C2);
  }
  return ans;
}

function kakeruR(a, b, C, C2){
  var tmpQ, tmpR, ans;
  tmpQ = (b / C2 | 0);
  tmpR = b - (tmpQ * C2);
  ans = (a * tmpQ % C) * C2 % C + (a * tmpR);
  ans %= C;
  return ans;
}

Main(require("fs").readFileSync("/dev/stdin", "utf8"));
