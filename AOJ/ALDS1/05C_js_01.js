// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_C/review/2304504/kyawakyawa/JavaScript
function Koch(n,p1x,p1y,p2x,p2y){
  if(n <= 0) {return ;}
  const sx = (p1x * 2 + p2x) / 3,sy = (p1y * 2 + p2y) / 3;
  Koch(n - 1,p1x,p1y,sx,sy);
  console.log(sx + " " + sy);
  const tx = (p1x + p2x * 2) / 3,ty = (p1y + p2y * 2) / 3;
  const ux = 0.5 * (tx + sx) - Math.sqrt(3) * 0.5 * (ty - sy),uy = Math.sqrt(3) * 0.5 * (tx - sx) + 0.5 * (ty + sy);
  Koch(n - 1,sx,sy,ux,uy);
  console.log(ux + " " + uy);
  Koch(n - 1,ux,uy,tx,ty);
  console.log(tx + " " + ty);
  Koch(n - 1,tx,ty,p2x,p2y);
}

function Main(input){
  const n = parseInt(input,10);
  console.log("0.00000000 0.00000000\n");
  Koch(n,0.0,0.0,100.0,0.0);
  console.log("100.00000000 0.00000000");
  return 0;
}

Main(require("fs").readFileSync("/dev/stdin","utf8"));
