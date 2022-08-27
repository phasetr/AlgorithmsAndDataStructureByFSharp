// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_C/review/3891031/n_mhn/JavaScript
function koch(n,ax,ay,bx,by){
  if(n===0) {return false;}

  const sx = (ax*2+bx)/3;
  const sy = (ay*2+by)/3;
  const tx = (bx*2+ax)/3;
  const ty = (by*2+ay)/3;
  const ux = (tx-sx)*Math.cos(Math.PI/3)-(ty-sy)*Math.sin(Math.PI/3) + sx;
  const uy = (tx-sx)*Math.sin(Math.PI/3) + (ty-sy)*Math.cos(Math.PI/3) +sy;

  koch(n-1,ax,ay,sx,sy);
  console.log(sx+" "+sy);
  koch(n-1,sx,sy,ux,uy);
  console.log(ux+" "+uy);
  koch(n-1,ux,uy,tx,ty);
  console.log(tx+" "+ty);
  koch(n-1,tx,ty,bx,by);
}
let num = parseInt(require("fs").readFileSync("/dev/stdin","utf-8").trim());
console.log(0,0);
koch(num,0,0,100,0);
console.log(100,0);
