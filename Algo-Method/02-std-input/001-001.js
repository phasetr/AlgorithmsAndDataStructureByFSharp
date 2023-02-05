let reader = require('readline').createInterface({
  input: process.stdin,
  output: process.stdout
});
let lines = [];
reader.on('line', function(line) {
  lines.push(parseInt(line,10));
});
reader.on('close', function() {
  console.log(lines[0]*2);
});
