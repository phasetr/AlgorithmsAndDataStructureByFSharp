// P.104
#include <iostream>
#include <stack>
using namespace std;
int main() {
  stack<int> S;

  S.push(3);
  cout << "Push 3 -> Stack top: " << S.top() << ", size: " << S.size() << endl;
  S.push(7);
  cout << "Push 7 -> Stack top: " << S.top() << ", size: " << S.size() << endl;
  S.push(1);
  cout << "Push 1 -> Stack top: " << S.top() << ", size: " << S.size() << endl;

  S.pop();
  cout << "Pop    -> Stack top: " << S.top() << ", size: " << S.size() << endl;
  S.pop();
  cout << "Pop    -> Stack top: " << S.top() << ", size: " << S.size() << endl;

  S.push(5);
  cout << "Push 5 -> Stack top: " << S.top() << ", size: " << S.size() << endl;

  S.pop();
  cout << "Pop    -> Stack top: " << S.top() << ", size: " << S.size() << endl;

  return 0;
}