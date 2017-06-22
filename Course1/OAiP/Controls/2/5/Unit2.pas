unit Unit2;

interface
type
   Tinf=record
      w,c:word;
   end;
   mas = array [1..20] of Tinf;

   Tzad=class(Tobject)
      a:mas;
      n:word;
      s,sopt:set of byte;
      wt,ct,wmax,cmax:word;
      procedure PP(i:word);
   end;

implementation


procedure Tzad.PP;
begin
   wt:=wt+a[i].w;
   ct:=ct+a[i].c;
   include(s,i);
   if i<n then PP(i+1)
   else if (wt<=wmax) and (ct>cmax) then
   begin
      sopt:=s;
      cmax:=ct;
   end;

   exclude(s,i);
   wt:=wt-a[i].w;
   ct:=ct-a[i].c;
   if i<n then PP(i+1)
   else if (wt<=wmax) and (ct>cmax) then
   begin
      sopt:=s;
      cmax:=ct;
   end;
end;

end.
 