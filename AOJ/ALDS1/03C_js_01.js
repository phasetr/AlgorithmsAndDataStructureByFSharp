// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_C/review/3850523/n_mhn/JavaScript
function main(input){
  const lines = input.split("\n");
  const length = parseInt(lines[0]);
  const orders = lines.slice(1);
  const put="";

  for(let i=0;i<length;i++){
    const order = orders[i].split(" ")[0];
    const key = orders[i].split(" ")[1];

    if(order==="insert"){
      if(put===""){
        put=key;
      }else{
        put = key+" "+put;

      }
    }else if(order==="delete"){
      const list = put.split(" ");
      const index = list.indexOf(key);
      if(index!==-1){
        list.splice(index,1);
        put = list.join(" ");
      }
    }else if(order==="deleteFirst"){
      while(!isNaN(parseInt(put[0]))){
        put=put.slice(1);
      }
      put = put.trim();
    }else if(order==="deleteLast"){
      while(!isNaN(parseInt(put[put.length-1]))){
        put=put.slice(0,-1);
      }
      put=put.trim();
    }
  }
  console.log(put.trim());
}

main(require("fs").readFileSync("/dev/stdin","utf-8"));
