// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_C/review/2312135/kyawakyawa/JavaScript
let h,hs = 0;

function insert(key){
  h[++hs] = key;
  let i = hs;
  while(h[i] > h[Math.floor(i / 2)]){
    var ex = h[i];
    h[i] = h[Math.floor(i / 2)];
    h[Math.floor(i / 2)] = ex;
    i = Math.floor(i / 2);
  }
}

function extract(){
  if(hs <= 0) return;

  let ret = h[1];
  h[1] = h[hs--];
  let i = 1;
  while((i * 2 <= hs && h[i] < h[i * 2]) || (i * 2 + 1 <= hs && h[i] < h[i * 2 + 1])){
    let l = i * 2;let r = i * 2;
    if(i * 2 + 1 <= hs)
      r++;
    let m = h[l] > h[r] ? l : r;
    let ex = h[i];
    h[i] = h[m];
    h[m] = ex;
    i = m;
  }
  return ret;
}

function Main(input){
  input = input.split("\n");
  h = new Array(2000000001);h[0] = 2000000001;

  let i = 0;
  while(1){
    if(input[i].charAt(0) == "i"){
      input[i] = input[i].split(" ");
      insert(parseInt(input[i][1],10));
    }else if(input[i].charAt(1) == "x"){
      console.log(extract());
    }else{
      break;
    }
    i++;
  }
}

Main(require("fs").readFileSync("/dev/stdin","utf8"));
