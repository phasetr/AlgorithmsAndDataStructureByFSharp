// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_D/review/1058991/ei1333/C++
#include <iostream>
#include <string>
using namespace std;

int main(){
  string str;
  int q;
  cin >> str;
  cin >> q;
  while(q--){
    string s;
    cin >> s;
    if(s == "print"){
      int a, b;
      cin >> a >> b;
      cout << str.substr(a, b - a + 1) << endl;
    } else if(s == "reverse"){
      int a, b;
      cin >> a >> b;
      reverse(str.begin() + a, str.begin() + b + 1);
    } else {
      int a, b;
      string p;
      cin >> a >> b >> p;
      str.replace(a, b - a + 1, p);
    }
  }
}
