// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_B/review/1287099/miraikako/JavaScript
function puzzle(){
  const obj={};
  obj["123456780"]=0;
  const dy=[-1,0,0,1];
  const dx=[0,-1,1,0];
  const V=[1,2,3,4,5,6,7,8,0];
  const P=[[V,0]];
  while(P.length>0){
    const A=P.shift();
    const arr=A[0];
    const cnt=A[1];
    const index=arr.indexOf(0);
    const y=Math.floor(index/3);
    const x=index%3;
    const yx=[arr.slice(0,3),arr.slice(3,6),arr.slice(6,9)];
    for(let i=0;i<4;i++){
      const yy=y+dy[i];
      const xx=x+dx[i];
      if(yy<0 || xx<0 || yy>=3 || xx>=3)continue;
      yx[y][x]=yx[yy][xx];
      const card=yx[yy][xx];
      yx[yy][xx]=0;
      const YX=yx[0].concat(yx[1],yx[2]);
      const str=YX.join("");
      if(obj.hasOwnProperty(str)==false){
        obj[str]=cnt+1;
        P.push([YX,cnt+1]);
      }
      yx[yy][xx]=card;
      yx[y][x]=0;
    }
  }
  return obj;
}
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const str=(input.trim()).replace(/\n|\s/g,"");
const PUZZLE=puzzle();
console.log(PUZZLE[str]);
