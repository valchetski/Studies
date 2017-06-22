function openStreetMapToggle() {
 var osm = $j('#openstreetmap')
 if (osm.length > 0)
   osm.toggle()
 else
   $j('#contentSub').append(
     '<iframe id="openstreetmap" style="width:100%; height:350px; clear:both"'
     + 'src="http://toolserver.org/~kolossos/openlayers/kml-on-ol.php?lang=ru&uselang=ru'
     + '&params='+ $j(this).attr('params')+'" />'
   )
 return false
}

function openStreetMapInit() {
  var c = $j('#coordinates'), aa = c.find('a')
  for (var i = 0; i < aa.length; i++)
    if (/geohack/.test(aa[i].href) && !/_globe:/.test(aa[i].href)){
      c.append('<br>').append(
        $j('<a href="#">Показать географическую карту</a>')
        .attr('params', aa[i].href.split('params=')[1])
        .click(openStreetMapToggle)
      )
      break
    }
}

addOnloadHook(openStreetMapInit)