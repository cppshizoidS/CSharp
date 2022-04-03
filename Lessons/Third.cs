//bitwise operations

int x1 = 2;
int y1 = 5;
Console.WriteLine(x1&y1);

int x2 = 4;
int y2 = 5;
Console.WriteLine(x2&y2);

int x3 = 2;
int y3 = 5;
Console.WriteLine(y3|y3);

int x4 = 4; 
int y4 = 5;
Console.WriteLine(x4 | y4);

int x = 45; 
int key = 102; 
 
int encrypt = x ^ key;
Console.WriteLine($"Encrypted: {encrypt}") ;
 
int decrypt = encrypt ^ key; 
Console.WriteLine($"Decrypted: {decrypt}");

int z = 12;                 
Console.WriteLine(~x);
