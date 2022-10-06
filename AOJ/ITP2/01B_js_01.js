// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP2_1_B/review/6476728/moritak/JavaScript
const input = 1 ? process.stdin : require('fs').createReadStream('./inp.txt');
const stdin = [];
require('readline').createInterface({ input }).on('line', (line) => stdin.push(line)).on('close', () => main(stdin, process.stdout));
function main(si, so) {
  const n = si[0].split(" ");
  let num = parseInt(n);
  let array = new Array(num);

  let head = num / 2;
  let tail = num / 2;
  let length = 0;

  for (let i = 1; i <= num; i++) {
    let order = si[i].split(" ");

    switch (order[0]) {
    case '0':
      if(order[1] === '0') {
        array[head] = order[2];
        if (length === 0) {
          head--;
          tail++;
        } else {
          head--;
        }
      }else{
        array[tail] = order[2];
        if (length === 0) {
          tail++;
          head--;
        } else {
          tail++;
        }

      }
      length++;
      break;
    case '1':
      let p = parseInt(order[1]) + head + 1;
      so.write(array[p] + '\n');
      break;
    case '2':
      if(order[1] === '0') {
        if (length === 1) {
          head++;
          tail--;
        } else {
          head++;
        }
      }else{
        if (length === 1) {
          tail--;
          head++;
        } else {
          tail--;
        }
      }
      length--;
      break;
    }
  }
}
