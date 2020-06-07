// P.106
#include <iostream>
#include <queue>
#include <string>
using namespace std;

int main() {
  queue<string> Q;

  printf("EMPTY       - front: %s, size: %ld\n", Q.front().c_str(), Q.size());

  Q.push("red");
  printf("PUSH red    - front: %s, size: %ld\n", Q.front().c_str(), Q.size());
  Q.push("yellow");
  printf("PUSH yellow - front: %s, size: %ld\n", Q.front().c_str(), Q.size());
  Q.push("yellow");
  printf("PUSH yellow - front: %s, size: %ld\n", Q.front().c_str(), Q.size());
  Q.push("blue");
  printf("PUSH blue   - front: %s, size: %ld\n", Q.front().c_str(), Q.size());

  Q.pop();
  printf("POP red     - front: %s, size: %ld\n", Q.front().c_str(), Q.size());
  Q.pop();
  printf("POP yellow  - front: %s, size: %ld\n", Q.front().c_str(), Q.size());
  Q.pop();
  printf("POP yellow  - front: %s, size: %ld\n", Q.front().c_str(), Q.size());

  Q.push("green");
  printf("PUSH green  - front: %s, size: %ld\n", Q.front().c_str(), Q.size());

  Q.pop();
  printf("POP blue    - front: %s, size: %ld\n", Q.front().c_str(), Q.size());
  Q.pop();
  printf("POP green   - front: %s, size: %ld\n", Q.front().c_str(), Q.size());
}
