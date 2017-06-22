unit Unit2;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Grids;

Type

Tinf = record
  f: shortstring;
  k: integer;
end;

TMas = array[1..1] of TInf;
PMas = ^TMas;

TList = class(TObject)
   a,a1: PMas;
   n,mt: word;
   constructor Create();
   procedure Add(inf:TInf);
   procedure Read(var inf:TInf);
   procedure Print(str: TStringGrid);
end;


implementation

constructor TList.Create();
begin
n:=0;
mt:=sizeof(TInf);
a:=nil;
end;

procedure TList.Add(inf:TInf);
var
 i:word;
begin
GetMem(a1,(n+1)*mt);
a1[n+1]:=inf;
if n>0 then
 for i:=1 to n do a1[i]:=a[i];
a:=a1;
n:=n+1;
end;

procedure TList.Read(var inf:TInf);
var
 i:word;
begin
if n>0 then
 begin
  inf:=a[1];
  n:=n-1;
  if n>0 then
   begin
    GetMem(a1,n* mt);
    for i:=1 to n do
     a1[i]:=a[i+1];
   end
  else a1:=nil;
  FreeMem(a,mt*(n+1));
  a:=a1;
 end
else showmessage('Список пуст!');
end;

procedure TList.Print(str: TStringGrid);
var i:integer;
begin
for i:=1 to n+1 do
begin
 str.Cells[0,i-1]:='';
 str.Cells[1,i-1]:='';
end;
if n=0 then
 showmessage('Список пуст!')
else
 begin
  for i:=1 to n do
   begin
    str.Cells[0,i-1]:=a[i].f;
    str.Cells[1,i-1]:=inttostr(a[i].k);
   end;
 end;
end;


end.
