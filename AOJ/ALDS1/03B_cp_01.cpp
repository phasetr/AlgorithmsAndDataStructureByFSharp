// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_B/review/1460109/yudedako/C++
#include <iostream>
#include <string>
using namespace std;

class Proc{
  string name;
  int time;
public:
  Proc(string n, int t) : name(n), time(t){}
  Proc() : name(""), time(0){}
  int execute(int q){return time -= q;};
  string get_name(){return name;};
  int get_time(){return time;};
};
int main(){
  int n, q;
  cin >> n >> q;
  Proc queue[n];
  string name;
  int time;
  for (int i = 0; i < n; i ++){
    cin >> name >> time;
    queue[i] = Proc(name, time);
  }
  int i = 0, last = 0, now_time = 0, size = n, temp = 0;
  while (size > 0){
    now_time += q;
    temp = queue[i].execute(q);
    if (temp <= 0){
      now_time += temp;
      cout << queue[i].get_name() << " " << now_time << "\n";
      size -= 1;
      i = (i + 1) % n;
    }else{
      queue[last] = queue[i];
      i = (i + 1) % n;
      last = (last + 1) % n;
    }
  }
}
