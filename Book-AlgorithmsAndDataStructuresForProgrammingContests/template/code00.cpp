#include <iostream>
#include <sstream>
#include <string>
using namespace std;

int main()
{
  int n = 10;
  int s[10];

  string input;
  cin >> input;

  istringstream iss(input);
  string tmpstr;
  int i = 0;
  while (iss >> tmpstr)
  {
    s[i] = stoi(tmpstr);
    cout << s[i] << endl;
    i++;
  }

  return 0;
}
