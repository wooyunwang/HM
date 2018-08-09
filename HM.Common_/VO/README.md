# VO

VO ：value object值对象 / view object表现层对象 
1 ．主要对应页面显示（web页面/swt、swing界面）的数据对象。 
2 ．可以和表对应，也可以不，这根据业务的需要。 
注 ：在struts中，用ActionForm做VO，需要做一个转换，因为PO是面向对象的，而ActionForm是和view对应的，要将几个PO要显示的属性合成一个ActionForm，可以使用BeanUtils的copy方法。