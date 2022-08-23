// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_D/review/4802731/etmt/JavaScript
function main(input = "") {
  const s1 = [];
  const s2 = [];
  for (let i = 0; i < input.length; i++) {
    const ch = input[i];
    if (ch === "\\") { s1.push(i); }
    else if (ch === "/" && s1.length > 0) {
      const k = s1.pop();
      const d = i - k;
      while (s2.length > 0 && s2[s2.length - 1][0] > k) {
        d += s2.pop()[1];
      }
      s2.push([k, d]);
    }
  }
  const lakes = s2.map((v) => (v[1]));
  if (lakes.length === 0) { return "0\n0"; }
  const sum = lakes.reduce((a, b) => (a + b));
  return sum + "\n" + lakes.length + " " + lakes.join(" ");
}

exports.main = main;
function Main(input) {
  console.log(main(input.trim()));
}
if (process.argv[2] !== "test") {
  Main(require("fs").readFileSync("/dev/stdin", "utf8"));
}
