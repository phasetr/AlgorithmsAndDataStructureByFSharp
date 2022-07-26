// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_B/review/6205649/RikiaR/JavaScript
(inputs=>{
  let i=0,h=0,len=0,sub=[];
  while(true){
    let fstr=inputs[i];
    let fstrlen=fstr.length;
    if (fstr==="-") {break;}
    len = Number(inputs[i+1]);
    for (let ii=0;ii<len;ii++){
      h = inputs[ii+i+2];
      sub[0] = fstr.substring(0,h);
      sub[1] = fstr.substring(h,fstrlen);
      fstr = sub[1]+sub[0];
    }
    console.log(fstr);
    i += len+2;
  }
})(require("fs").readFileSync("/dev/stdin","utf-8").trim("\n").split("\n"));
