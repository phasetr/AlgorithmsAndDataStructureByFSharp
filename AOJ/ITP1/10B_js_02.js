// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_B/review/1492067/miura100/JavaScript
process.stdin.resume();
process.stdin.setEncoding('utf8');
process.stdin.on('data', function (chunk){
  const x = chunk.split(" ");
  const a = parseFloat(x[0]);
  const b = parseFloat(x[1]);
  const c = parseFloat(x[2]);

  const c_rad = c / 180 * Math.PI;
  const s = 0.5 * a * b * Math.sin(c_rad);
  const l = a + b + Math.sqrt(a * a + b * b - 2 * a * b * Math.cos(c_rad));
  const h = s / a * 2;

  console.log(s);
  console.log(l);
  console.log(h);
});
