%������� ���������� ��������������� ����
%���: n^(1/2)/n^(x^2-1) n=1,2...
syms s n x f str res
str = '';
assume(n>0);
assume(x,'rational');
f = n^(1/2)/n^(x^2-1);
f = simplify(f);
s = symsum(f,n,1,inf);
if(s ~= inf)
    %��������� ������� �� ���������� ����� 
    str = char(s);
    disp(s);
    strstart = strfind(str, '[');
    strend = strfind(str,',');
    res = str(strstart + 1: strend - 1);
    disp(strcat('������� ����������: ',res));
else
    disp('���������� ��� ����� x');
end;
%���������: ������� ����������: x^2 > 5/2

