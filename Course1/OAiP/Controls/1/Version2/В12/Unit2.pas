unit Unit2;

interface
function provka(s : string):integer;
implementation
function provka(s : string):integer;
var a : set of char;
    n, p, i : integer;
begin
a:=[];
p:=0;
n:=length(s);
for i:=1 to n do
if not(s[i] in a) then begin
                          include(a,s[i]);
                          inc(p);
                          end;
Result:=p;
end;
end.
 