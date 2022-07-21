// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_A/review/4260466/SSRS/C++
#include <iostream>
using namespace std;
int main(){
  string s;
  getline(cin, s);
  for (int i = 0; i < s.size(); i++){
    char c = s[i];
    if (islower(c)){
      cout << (char)toupper(c);
    } else {
      cout << (char)tolower(c);
    }
  }
  cout << endl;
}
