md %1\eko
md %1\eko\eco_doc
copy eko1.arj %1\eko
copy eko2.arj %1\eko
copy keyrus.com %1\eko
copy eco_doc\eco_doc.arj %1\eko\eco_doc
cd %1\eko
arj x %1\eko\eko1.arj %1\eko
arj x %1\eko\eko2.arj %1\eko
del %1\eko\eko1.arj 
del %1\eko\eko2.arj 
