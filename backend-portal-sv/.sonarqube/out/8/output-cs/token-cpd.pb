π
ÄC:\Users\ifspn\OneDrive\Desktop\APPS\backend-portal-sv\backend-portal-sv\backend-portal-sv\SwaggerConfig\SwaggerDefaultValues.cs
	namespace 	
backend_portal_sv
 
. 
SwaggerConfig )
{ 
public 

class  
SwaggerDefaultValues %
:& '
IOperationFilter( 8
{ 
public		 
void		 
Apply		 
(		 
OpenApiOperation		 *
	operation		+ 4
,		4 5"
OperationFilterContext		6 L
context		M T
)		T U
{

 	
var 
apiDescription 
=  
context! (
.( )
ApiDescription) 7
;7 8
if 
( 
	operation 
. 

Parameters $
==% '
null( ,
), -
{ 
return 
; 
} 
foreach 
( 
var 
	parameter "
in# %
	operation& /
./ 0

Parameters0 :
): ;
{ 
var 
description 
=  !
apiDescription" 0
.0 1!
ParameterDescriptions1 F
.F G
FirstG L
(L M
pM N
=>O Q
pR S
.S T
NameT X
==Y [
	parameter\ e
.e f
Namef j
)j k
;k l
if 
( 
	parameter 
. 
Description )
==* ,
null- 1
)1 2
{ 
	parameter 
. 
Description )
=* +
description, 7
.7 8
ModelMetadata8 E
?E F
.F G
DescriptionG R
;R S
} 
if 
( 
	parameter 
. 
Schema $
.$ %
Default% ,
==- /
null0 4
&&5 7
description8 C
.C D
DefaultValueD P
!=Q S
nullT X
)X Y
{ 
	parameter 
. 
Schema $
.$ %
Default% ,
=- .
new/ 2
OpenApiString3 @
(@ A
descriptionA L
.L M
DefaultValueM Y
.Y Z
ToStringZ b
(b c
)c d
)d e
;e f
} 
	parameter   
.   
Required   "
|=  # %
description  & 1
.  1 2

IsRequired  2 <
;  < =
}!! 
}"" 	
}## 
}%% ∏
ÜC:\Users\ifspn\OneDrive\Desktop\APPS\backend-portal-sv\backend-portal-sv\backend-portal-sv\SwaggerConfig\ConfigureSwaggerGenOptions.cs
	namespace 	
backend_portal_sv
 
. 
SwaggerConfig )
{ 
public 

class &
ConfigureSwaggerGenOptions +
:, -
IConfigureOptions. ?
<? @
SwaggerGenOptions@ Q
>Q R
{		 
private

 
readonly

 *
IApiVersionDescriptionProvider

 7
	_provider

8 A
;

A B
public &
ConfigureSwaggerGenOptions )
() **
IApiVersionDescriptionProvider* H
providerI Q
)Q R
{ 	
	_provider 
= 
provider  
??! #
throw$ )
new* -!
ArgumentNullException. C
(C D
nameofD J
(J K
providerK S
)S T
)T U
;U V
} 	
public 
void 
	Configure 
( 
SwaggerGenOptions /
options0 7
)7 8
{ 	
foreach 
( 
var 
description $
in% '
	_provider( 1
.1 2"
ApiVersionDescriptions2 H
)H I
{ 
options 
. 

SwaggerDoc "
(" #
description# .
.. /
	GroupName/ 8
,8 9 
CreateApiVersionInfo: N
(N O
descriptionO Z
)Z [
)[ \
;\ ]
} 
} 	
private 
OpenApiInfo  
CreateApiVersionInfo 0
(0 1!
ApiVersionDescription1 F
descriptionG R
)R S
{ 	
return 
new 
OpenApiInfo "
{ 
Title 
= 
$str 2
,2 3
Version 
= 
description %
.% &

ApiVersion& 0
.0 1
ToString1 9
(9 :
): ;
,; <
Description 
= 
$str	 ∏
,
∏ π
Contact   
=   
new   
OpenApiContact   ,
{!! 
Name"" 
="" 
$str"" 4
,""4 5
Email## 
=## 
$str## 4
}$$ 
,$$ 
License%% 
=%% 
new%% 
OpenApiLicense%% ,
{&& 
Name'' 
='' 
$str'' M
}(( 
})) 
;)) 
}** 	
}++ 
},, ‡U
eC:\Users\ifspn\OneDrive\Desktop\APPS\backend-portal-sv\backend-portal-sv\backend-portal-sv\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder 
. 
Services 
. #
AddEndpointsApiExplorer (
(( )
)) *
;* +
builder 
. 
Services 
. 
AddDbContext 
< 
ConnectionContext /
>/ 0
(0 1
)1 2
;2 3
builder 
. 
Services 
. 
	AddScoped 
< 
IStorageHandler *
,* +
StorageHandler, :
>: ;
(; <
)< =
;= >
builder   
.   
Services   
.   
	AddScoped   
<   
IClienteRepository   -
,  - .
ClienteRepository  / @
>  @ A
(  A B
)  B C
;  C D
builder!! 
.!! 
Services!! 
.!! 
	AddScoped!! 
<!! 
IChatbotRepository!! -
,!!- .
ChatbotRepository!!/ @
>!!@ A
(!!A B
)!!B C
;!!C D
builder%% 
.%% 
Services%% 
.%% 
	AddScoped%% 
<%% 
IClienteService%% *
,%%* +
ClienteService%%, :
>%%: ;
(%%; <
)%%< =
;%%= >
builder&& 
.&& 
Services&& 
.&& 
	AddScoped&& 
<&& 
ITokenService&& (
,&&( )
TokenService&&* 6
>&&6 7
(&&7 8
)&&8 9
;&&9 :
builder'' 
.'' 
Services'' 
.'' 
	AddScoped'' 
<'' 
IChatbotService'' *
,''* +
ChatbotService'', :
>'': ;
(''; <
)''< =
;''= >
builder++ 
.++ 
Services++ 
.++ 
AddSingleton++ 
<++ 
Serilog++ %
.++% &
ILogger++& -
>++- .
(++. /
new++/ 2
LoggerConfiguration++3 F
(++F G
)++G H
.,, 
CreateLogger,, 
(,, 
),, 
),, 
;,, 
builder// 
.// 
Services// 
.// 
AddApiVersioning// !
(//! "
)//" #
.//# $
AddMvc//$ *
(//* +
)//+ ,
.//, -
AddApiExplorer//- ;
(//; <
setup//< A
=>//B D
{00 
setup11 	
.11	 

GroupNameFormat11
 
=11 
$str11 $
;11$ %
setup22 	
.22	 
%
SubstituteApiVersionInUrl22
 #
=22$ %
true22& *
;22* +
}33 
)33 
;33 
builder44 
.44 
Services44 
.44 
ConfigureOptions44 !
<44! "&
ConfigureSwaggerGenOptions44" <
>44< =
(44= >
)44> ?
;44? @
builder88 
.88 
Services88 
.88 
AddSwaggerGen88 
(88 
c88  
=>88! #
{99 
c:: 
.:: 
OperationFilter:: 
<::  
SwaggerDefaultValues:: *
>::* +
(::+ ,
)::, -
;::- .
c;; 
.;; !
AddSecurityDefinition;; 
(;; 
$str;; $
,;;$ %
new;;& )!
OpenApiSecurityScheme;;* ?
{<< 
Name== 
=== 
$str== 
,== 
Type>> 
=>> 
SecuritySchemeType>> !
.>>! "
ApiKey>>" (
,>>( )
In?? 

=?? 
ParameterLocation?? 
.?? 
Header?? %
,??% &
Description@@ 
=@@ 
$str@@ &
,@@& '
SchemeAA 
=AA 
$strAA 
}BB 
)BB 
;BB 
cDD 
.DD "
AddSecurityRequirementDD 
(DD 
newDD  &
OpenApiSecurityRequirementDD! ;
{EE 
{FF 	
newGG !
OpenApiSecuritySchemeGG %
{HH 
	ReferenceII 
=II 
newII 
OpenApiReferenceII  0
{JJ 
TypeKK 
=KK 
ReferenceTypeKK (
.KK( )
SecuritySchemeKK) 7
,KK7 8
IdLL 
=LL 
$strLL !
}MM 
,MM 
SchemeNN 
=NN 
$strNN !
,NN! "
NameOO 
=OO 
$strOO 
,OO  
InPP 
=PP 
ParameterLocationPP &
.PP& '
HeaderPP' -
}QQ 
,QQ 
newRR 
stringRR 
[RR 
]RR 
{RR 
}RR 
}SS 	
}TT 
)TT 
;TT 
varUU 
xmlFileUU 
=UU 
$"UU 
{UU 
AssemblyUU 
.UU  
GetExecutingAssemblyUU 2
(UU2 3
)UU3 4
.UU4 5
GetNameUU5 <
(UU< =
)UU= >
.UU> ?
NameUU? C
}UUC D
$strUUD H
"UUH I
;UUI J
varVV 
xmlPathVV 
=VV 
PathVV 
.VV 
CombineVV 
(VV 

AppContextVV )
.VV) *
BaseDirectoryVV* 7
,VV7 8
xmlFileVV9 @
)VV@ A
;VVA B
cWW 
.WW 
IncludeXmlCommentsWW 
(WW 
xmlPathWW  
)WW  !
;WW! "
}XX 
)XX 
;XX 
builder\\ 
.\\ 
Services\\ 
.\\ 
	Configure\\ 
<\\ 
HttpResponse\\ '
>\\' (
(\\( )
options\\) 0
=>\\1 3
{]] 
options^^ 
.^^ 
Headers^^ 
.^^ 
Add^^ 
(^^ 
$str^^ &
,^^& '
$str^^( I
)^^I J
;^^J K
}__ 
)__ 
;__ 
buildercc 
.cc 
Servicescc 
.cc 
AddAuthenticationcc "
(cc" #
xcc# $
=>cc% '
{dd 
xee 
.ee %
DefaultAuthenticateSchemeee 
=ee  !
JwtBearerDefaultsee" 3
.ee3 4 
AuthenticationSchemeee4 H
;eeH I
xff 
.ff "
DefaultChallengeSchemeff 
=ff 
JwtBearerDefaultsff 0
.ff0 1 
AuthenticationSchemeff1 E
;ffE F
}gg 
)gg 
.gg 
AddJwtBearergg 
(gg 
xgg 
=>gg 
{hh 
xii 
.ii  
RequireHttpsMetadataii 
=ii 
falseii "
;ii" #
xjj 
.jj 
	SaveTokenjj 
=jj 
truejj 
;jj 
xkk 
.kk %
TokenValidationParameterskk 
=kk  !
newkk" %%
TokenValidationParameterskk& ?
{ll $
ValidateIssuerSigningKeymm  
=mm! "
truemm# '
,mm' (
IssuerSigningKeynn 
=nn 
newnn  
SymmetricSecurityKeynn 3
(nn3 4
Encodingnn4 <
.nn< =
ASCIInn= B
.nnB C
GetBytesnnC K
(nnK L
buildernnL S
.nnS T
ConfigurationnnT a
[nna b
$strnnb n
]nnn o
??nnp r
$strnns u
)nnu v
)nnv w
,nnw x
ValidateIssueroo 
=oo 
falseoo 
,oo 
ValidateAudiencepp 
=pp 
falsepp  
}qq 
;qq 
}rr 
)rr 
;rr 
varuu 
appuu 
=uu 	
builderuu
 
.uu 
Builduu 
(uu 
)uu 
;uu 
ifyy 
(yy 
appyy 
.yy 
Environmentyy 
.yy 
IsDevelopmentyy !
(yy! "
)yy" #
)yy# $
{zz 
app{{ 
.{{ 
UseExceptionHandler{{ 
({{ 
$str{{ (
){{( )
;{{) *
app|| 
.|| 

UseSwagger|| 
(|| 
)|| 
;|| 
app}} 
.}} 
UseSwaggerUI}} 
(}} 
options}} 
=>}} 
{~~ 
var 
version 
= 
app 
. 
Services "
." #
GetRequiredService# 5
<5 6*
IApiVersionDescriptionProvider6 T
>T U
(U V
)V W
;W X
foreach
ÄÄ 
(
ÄÄ 
var
ÄÄ 
item
ÄÄ 
in
ÄÄ 
version
ÄÄ $
.
ÄÄ$ %$
ApiVersionDescriptions
ÄÄ% ;
)
ÄÄ; <
{
ÅÅ 	
options
ÇÇ 
.
ÇÇ 
SwaggerEndpoint
ÇÇ #
(
ÇÇ# $
$"
ÇÇ$ &
$str
ÇÇ& /
{
ÇÇ/ 0
item
ÇÇ0 4
.
ÇÇ4 5
	GroupName
ÇÇ5 >
}
ÇÇ> ?
$str
ÇÇ? L
"
ÇÇL M
,
ÇÇM N
$"
ÇÇO Q
$str
ÇÇQ ^
{
ÇÇ^ _
item
ÇÇ_ c
.
ÇÇc d
	GroupName
ÇÇd m
.
ÇÇm n
ToUpper
ÇÇn u
(
ÇÇu v
)
ÇÇv w
}
ÇÇw x
"
ÇÇx y
)
ÇÇy z
;
ÇÇz {
}
ÉÉ 	
}
ÑÑ 
)
ÑÑ 
;
ÑÑ 
}ÖÖ 
elseÜÜ 
{áá 
app
àà 
.
àà !
UseExceptionHandler
àà 
(
àà 
$str
àà $
)
àà$ %
;
àà% &
}ââ 
appãã 
.
ãã 
UseCors
ãã 
(
ãã 
$str
ãã 
)
ãã 
;
ãã 
appåå 
.
åå !
UseHttpsRedirection
åå 
(
åå 
)
åå 
;
åå 
appçç 
.
çç  
UseStatusCodePages
çç 
(
çç 
)
çç 
;
çç 
appéé 
.
éé 
UseAuthorization
éé 
(
éé 
)
éé 
;
éé 
appèè 
.
èè 
MapControllers
èè 
(
èè 
)
èè 
;
èè 
awaitíí 
app
íí 	
.
íí	 

RunAsync
íí
 
(
íí 
)
íí 
;
íí Ë?
~C:\Users\ifspn\OneDrive\Desktop\APPS\backend-portal-sv\backend-portal-sv\backend-portal-sv\Controllers\v1\ChatbotController.cs
	namespace 	
backend_portal_sv
 
. 
Controllers '
.' (
v1( *
{ 
[		 
ApiController		 
]		 
[

 
Route

 

(


 
$str

 3
)

3 4
]

4 5
[ 

ApiVersion 
( 
$str 
) 
] 
[ 
Produces 
( 
$str  
)  !
]! "
[ 
Tags 	
(	 

$str
 
) 
] 
public 

class 
ChatbotController "
:# $
ControllerBase% 3
{ 
private 
readonly 
IChatbotService (
_chatbotService) 8
;8 9
public 
ChatbotController  
(  !
IChatbotService! 0
chatbotService1 ?
)? @
{ 	
_chatbotService 
= 
chatbotService ,
??- /
throw0 5
new6 9!
ArgumentNullException: O
(O P
nameofP V
(V W
chatbotServiceW e
)e f
)f g
;g h
} 	
["" 	
HttpPost""	 
]"" 
[## 	 
ProducesResponseType##	 
(## 
StatusCodes## )
.##) *
Status200OK##* 5
)##5 6
]##6 7
[$$ 	 
ProducesResponseType$$	 
($$ 
StatusCodes$$ )
.$$) *!
Status401Unauthorized$$* ?
)$$? @
]$$@ A
[%% 	 
ProducesResponseType%%	 
(%% 
StatusCodes%% )
.%%) *(
Status500InternalServerError%%* F
)%%F G
]%%G H
public&& 
async&& 
Task&& 
<&& 
IActionResult&& '
>&&' (
SendMessage&&) 4
(&&4 5
string&&5 ;
message&&< C
)&&C D
{'' 	
try(( 
{)) 
var** 
returnMessage** !
=**" #
await**$ )
_chatbotService*** 9
.**9 :
SendMessage**: E
(**E F
message**F M
)**M N
;**N O
return++ 
Ok++ 
(++ 
returnMessage++ '
)++' (
;++( )
},, 
catch-- 
(-- !
HttpResponseException-- (
ex--) +
)--+ ,
{.. 
return// 

StatusCode// !
(//! "
(//" #
int//# &
)//& '
ex//' )
.//) *

StatusCode//* 4
,//4 5
ex//6 8
.//8 9
Message//9 @
)//@ A
;//A B
}00 
catch11 
(11 
	Exception11 
e11 
)11 
{22 
throw33 
;33 
}44 
}55 	
[@@ 	
HttpPost@@	 
(@@ 
$str@@ "
)@@" #
]@@# $
[AA 	 
ProducesResponseTypeAA	 
(AA 
StatusCodesAA )
.AA) *
Status201CreatedAA* :
)AA: ;
]AA; <
[BB 	 
ProducesResponseTypeBB	 
(BB 
StatusCodesBB )
.BB) *!
Status401UnauthorizedBB* ?
)BB? @
]BB@ A
[CC 	 
ProducesResponseTypeCC	 
(CC 
StatusCodesCC )
.CC) *(
Status500InternalServerErrorCC* F
)CCF G
]CCG H
publicDD 
asyncDD 
TaskDD 
<DD 
IActionResultDD '
>DD' (
CriaHistoricoDD) 6
(DD6 7
ChatDtoDD7 >
chatDD? C
)DDC D
{DDD E
tryEE 
{FF 
awaitGG 
_chatbotServiceGG %
.GG% &
CriaHistoricoGG& 3
(GG3 4
chatGG4 8
)GG8 9
;GG9 :
returnHH 
CreatedHH 
(HH 
)HH  
;HH  !
}II 
catchJJ 
(JJ !
HttpResponseExceptionJJ (
exJJ) +
)JJ+ ,
{KK 
returnLL 

StatusCodeLL !
(LL! "
(LL" #
intLL# &
)LL& '
exLL' )
.LL) *

StatusCodeLL* 4
,LL4 5
exLL6 8
.LL8 9
MessageLL9 @
)LL@ A
;LLA B
}MM 
catchNN 
(NN 
	ExceptionNN 
eNN 
)NN 
{OO 
throwPP 
;PP 
}QQ 
}RR 	
[[[ 	
HttpPut[[	 
][[ 
[\\ 	 
ProducesResponseType\\	 
(\\ 
StatusCodes\\ )
.\\) *
Status204NoContent\\* <
)\\< =
]\\= >
[]] 	 
ProducesResponseType]]	 
(]] 
StatusCodes]] )
.]]) *!
Status401Unauthorized]]* ?
)]]? @
]]]@ A
[^^ 	 
ProducesResponseType^^	 
(^^ 
StatusCodes^^ )
.^^) *(
Status500InternalServerError^^* F
)^^F G
]^^G H
public__ 
async__ 
Task__ 
<__ 
IActionResult__ '
>__' (
AtualizaHistorico__) :
(__: ;
ChatDto__; B
chat__C G
)__G H
{__H I
try`` 
{aa 
awaitbb 
_chatbotServicebb %
.bb% &
AtualizaHistoricobb& 7
(bb7 8
chatbb8 <
)bb< =
;bb= >
returncc 
	NoContentcc  
(cc  !
)cc! "
;cc" #
}dd 
catchee 
(ee !
HttpResponseExceptionee (
exee) +
)ee+ ,
{ff 
returngg 

StatusCodegg !
(gg! "
(gg" #
intgg# &
)gg& '
exgg' )
.gg) *

StatusCodegg* 4
,gg4 5
exgg6 8
.gg8 9
Messagegg9 @
)gg@ A
;ggA B
}hh 
catchii 
(ii 
	Exceptionii 
eii 
)ii 
{jj 
throwkk 
;kk 
}ll 
}mm 	
[ww 	
HttpGetww	 
]ww 
[xx 	 
ProducesResponseTypexx	 
(xx 
StatusCodesxx )
.xx) *
Status200OKxx* 5
)xx5 6
]xx6 7
[yy 	 
ProducesResponseTypeyy	 
(yy 
StatusCodesyy )
.yy) *!
Status401Unauthorizedyy* ?
)yy? @
]yy@ A
[zz 	 
ProducesResponseTypezz	 
(zz 
StatusCodeszz )
.zz) *(
Status500InternalServerErrorzz* F
)zzF G
]zzG H
public{{ 
async{{ 
Task{{ 
<{{ 
IActionResult{{ '
>{{' (
PegaHistoricos{{) 7
({{7 8
){{8 9
{{{: ;
try|| 
{}} 
var~~ 
returnMessage~~ !
=~~" #
await~~$ )
_chatbotService~~* 9
.~~9 :
PegaHistoricos~~: H
(~~H I
)~~I J
;~~J K
return 
Ok 
( 
returnMessage '
)' (
;( )
}
ÄÄ 
catch
ÅÅ 
(
ÅÅ #
HttpResponseException
ÅÅ (
ex
ÅÅ) +
)
ÅÅ+ ,
{
ÇÇ 
return
ÉÉ 

StatusCode
ÉÉ !
(
ÉÉ! "
(
ÉÉ" #
int
ÉÉ# &
)
ÉÉ& '
ex
ÉÉ' )
.
ÉÉ) *

StatusCode
ÉÉ* 4
,
ÉÉ4 5
ex
ÉÉ6 8
.
ÉÉ8 9
Message
ÉÉ9 @
)
ÉÉ@ A
;
ÉÉA B
}
ÑÑ 
catch
ÖÖ 
(
ÖÖ 
	Exception
ÖÖ 
e
ÖÖ 
)
ÖÖ 
{
ÜÜ 
throw
áá 
;
áá 
}
àà 
}
ââ 	
}
ää 
}ãã ◊P
~C:\Users\ifspn\OneDrive\Desktop\APPS\backend-portal-sv\backend-portal-sv\backend-portal-sv\Controllers\v1\ClienteController.cs
	namespace 	
backend_portal_sv
 
. 
Controllers '
.' (
v1( *
{		 
[

 
ApiController

 
]

 
[ 
Route 

(
 
$str .
). /
]/ 0
[ 
Produces 
( 
$str  
)  !
]! "
[ 
Tags 	
(	 

$str
 
) 
] 
[ 

ApiVersion 
( 
$num 
) 
] 
public 

class 
ClienteController "
:# $
ControllerBase% 3
{ 
private 
readonly 
IClienteService (
_clienteService) 8
;8 9
public 
ClienteController  
(  !
IClienteService! 0
clienteService1 ?
)? @
{ 	
_clienteService 
= 
clienteService ,
;, -
} 	
[$$ 	
	Authorize$$	 
]$$ 
[%% 	
HttpPost%%	 
]%% 
[&& 	 
ProducesResponseType&&	 
(&& 
StatusCodes&& )
.&&) *
Status201Created&&* :
)&&: ;
]&&; <
['' 	 
ProducesResponseType''	 
('' 
StatusCodes'' )
.'') *!
Status401Unauthorized''* ?
)''? @
]''@ A
[(( 	 
ProducesResponseType((	 
((( 
StatusCodes(( )
.(() *(
Status500InternalServerError((* F
)((F G
]((G H
public)) 
async)) 
Task)) 
<)) 
IActionResult)) '
>))' (
Create))) /
())/ 0

ClienteDTO))0 :
cliente)); B
)))B C
{** 	
try++ 
{,, 
await-- 
_clienteService-- %
.--% &
Add--& )
(--) *
cliente--* 1
)--1 2
;--2 3
return.. 
Created.. 
(.. 
)..  
;..  !
}// 
catch00 
(00 !
HttpResponseException00 (
ex00) +
)00+ ,
{11 
return22 

StatusCode22 !
(22! "
(22" #
int22# &
)22& '
ex22' )
.22) *

StatusCode22* 4
,224 5
ex226 8
.228 9
Message229 @
)22@ A
;22A B
}33 
catch44 
(44 
	Exception44 
ex44 
)44  
{55 
throw66 
;66 
}77 
}88 	
[CC 	
HttpGetCC	 
]CC 
[DD 	 
ProducesResponseTypeDD	 
(DD 
StatusCodesDD )
.DD) *
Status200OKDD* 5
)DD5 6
]DD6 7
[EE 	 
ProducesResponseTypeEE	 
(EE 
StatusCodesEE )
.EE) *!
Status401UnauthorizedEE* ?
)EE? @
]EE@ A
[FF 	 
ProducesResponseTypeFF	 
(FF 
StatusCodesFF )
.FF) *(
Status500InternalServerErrorFF* F
)FFF G
]FFG H
publicGG 
asyncGG 
TaskGG 
<GG 
IActionResultGG '
>GG' (
GetAllClientesGG) 7
(GG7 8
intGG8 ;
numero_paginaGG< I
,GGI J
intGGK N
quantidade_p_paginaGGO b
)GGb c
{II 	
tryJJ 
{KK 
varLL 
clientesLL 
=LL 
awaitLL $
_clienteServiceLL% 4
.LL4 5
GetAllLL5 ;
(LL; <
numero_paginaLL< I
,LLI J
quantidade_p_paginaLLK ^
)LL^ _
;LL_ `
returnMM 
OkMM 
(MM 
clientesMM "
)MM" #
;MM# $
}NN 
catchOO 
(OO 
	ExceptionOO 
exOO 
)OO  
{PP 
throwQQ 
;QQ 
}RR 
}SS 	
[__ 	
HttpGet__	 
(__ 
$str__ 
)__ 
]__ 
[`` 	 
ProducesResponseType``	 
(`` 
StatusCodes`` )
.``) *
Status200OK``* 5
)``5 6
]``6 7
[aa 	 
ProducesResponseTypeaa	 
(aa 
StatusCodesaa )
.aa) *!
Status401Unauthorizedaa* ?
)aa? @
]aa@ A
[bb 	 
ProducesResponseTypebb	 
(bb 
StatusCodesbb )
.bb) *
Status404NotFoundbb* ;
)bb; <
]bb< =
[cc 	 
ProducesResponseTypecc	 
(cc 
StatusCodescc )
.cc) *(
Status500InternalServerErrorcc* F
)ccF G
]ccG H
publicdd 
asyncdd 
Taskdd 
<dd 
IActionResultdd '
>dd' (
GetClienteByIddd) 7
(dd7 8
intdd8 ;
iddd< >
)dd> ?
{ee 	
tryff 
{gg 
varhh 
clientehh 
=hh 
awaithh #
_clienteServicehh$ 3
.hh3 4
Gethh4 7
(hh7 8
idhh8 :
)hh: ;
;hh; <
ifii 
(ii 
clienteii 
==ii 
nullii #
)ii# $
returnjj 
NotFoundjj #
(jj# $
$strjj$ =
)jj= >
;jj> ?
returnll 
Okll 
(ll 
clientell !
)ll! "
;ll" #
}mm 
catchnn 
(nn 
	Exceptionnn 
exnn 
)nn  
{oo 
throwpp 
;pp 
}qq 
}rr 	
[}} 	
	Authorize}}	 
]}} 
[~~ 	
	HttpPatch~~	 
]~~ 
[ 	 
ProducesResponseType	 
( 
StatusCodes )
.) *
Status204NoContent* <
)< =
]= >
[
ÄÄ 	"
ProducesResponseType
ÄÄ	 
(
ÄÄ 
StatusCodes
ÄÄ )
.
ÄÄ) *#
Status401Unauthorized
ÄÄ* ?
)
ÄÄ? @
]
ÄÄ@ A
[
ÅÅ 	"
ProducesResponseType
ÅÅ	 
(
ÅÅ 
StatusCodes
ÅÅ )
.
ÅÅ) *
Status404NotFound
ÅÅ* ;
)
ÅÅ; <
]
ÅÅ< =
[
ÇÇ 	"
ProducesResponseType
ÇÇ	 
(
ÇÇ 
StatusCodes
ÇÇ )
.
ÇÇ) **
Status500InternalServerError
ÇÇ* F
)
ÇÇF G
]
ÇÇG H
public
ÉÉ 
async
ÉÉ 
Task
ÉÉ 
<
ÉÉ 
IActionResult
ÉÉ '
>
ÉÉ' (
UpdateCliente
ÉÉ) 6
(
ÉÉ6 7
[
ÉÉ7 8
FromBody
ÉÉ8 @
]
ÉÉ@ A

ClienteDTO
ÉÉB L
cliente
ÉÉM T
)
ÉÉT U
{
ÑÑ 	
try
ÖÖ 
{
ÜÜ 
var
áá 
existingCliente
áá #
=
áá$ %
await
áá& +
_clienteService
áá, ;
.
áá; <
Get
áá< ?
(
áá? @
cliente
áá@ G
.
ááG H
Id
ááH J
)
ááJ K
;
ááK L
if
àà 
(
àà 
existingCliente
àà #
==
àà$ &
null
àà' +
)
àà+ ,
return
ââ 
NotFound
ââ #
(
ââ# $
$str
ââ$ =
)
ââ= >
;
ââ> ?
await
ãã 
_clienteService
ãã %
.
ãã% &
Update
ãã& ,
(
ãã, -
cliente
ãã- 4
)
ãã4 5
;
ãã5 6
return
åå 
Ok
åå 
(
åå 
$str
åå ;
)
åå; <
;
åå< =
}
çç 
catch
éé 
(
éé 
	Exception
éé 
ex
éé 
)
éé  
{
èè 
throw
êê 
;
êê 
}
ëë 
}
íí 	
[
ùù 	
	Authorize
ùù	 
]
ùù 
[
ûû 	

HttpDelete
ûû	 
(
ûû 
$str
ûû 
)
ûû 
]
ûû  
[
üü 	"
ProducesResponseType
üü	 
(
üü 
StatusCodes
üü )
.
üü) * 
Status204NoContent
üü* <
)
üü< =
]
üü= >
[
†† 	"
ProducesResponseType
††	 
(
†† 
StatusCodes
†† )
.
††) *#
Status401Unauthorized
††* ?
)
††? @
]
††@ A
[
°° 	"
ProducesResponseType
°°	 
(
°° 
StatusCodes
°° )
.
°°) *
Status404NotFound
°°* ;
)
°°; <
]
°°< =
[
¢¢ 	"
ProducesResponseType
¢¢	 
(
¢¢ 
StatusCodes
¢¢ )
.
¢¢) **
Status500InternalServerError
¢¢* F
)
¢¢F G
]
¢¢G H
public
££ 
async
££ 
Task
££ 
<
££ 
IActionResult
££ '
>
££' (
DeleteCliente
££) 6
(
££6 7
int
££7 :
id
££; =
)
££= >
{
§§ 	
try
•• 
{
¶¶ 
var
ßß 
cliente
ßß 
=
ßß 
await
ßß #
_clienteService
ßß$ 3
.
ßß3 4
Get
ßß4 7
(
ßß7 8
id
ßß8 :
)
ßß: ;
;
ßß; <
if
®® 
(
®® 
cliente
®® 
==
®® 
null
®® #
)
®®# $
return
©© 
NotFound
©© #
(
©©# $
$str
©©$ =
)
©©= >
;
©©> ?
await
´´ 
_clienteService
´´ %
.
´´% &
Delete
´´& ,
(
´´, -
cliente
´´- 4
)
´´4 5
;
´´5 6
return
¨¨ 
Ok
¨¨ 
(
¨¨ 
$str
¨¨ 9
)
¨¨9 :
;
¨¨: ;
}
≠≠ 
catch
ÆÆ 
(
ÆÆ 
	Exception
ÆÆ 
ex
ÆÆ 
)
ÆÆ  
{
ØØ 
throw
∞∞ 
;
∞∞ 
}
±± 
}
≤≤ 	
}
≥≥ 
}¥¥ ”
yC:\Users\ifspn\OneDrive\Desktop\APPS\backend-portal-sv\backend-portal-sv\backend-portal-sv\Controllers\ThrowController.cs
	namespace 	
backend_portal_sv
 
. 
Controllers '
{ 
[ 
ApiExplorerSettings 
( 
	IgnoreApi "
=# $
true% )
)) *
]* +
public 

class 
ThrowController  
:! "
ControllerBase# 1
{ 
[		 	
Route			 
(		 
$str		 
)		 
]		 
public

 
IActionResult

 
HandleError

 (
(

( )
)

) *
=>

+ -
Problem

. 5
(

5 6
)

6 7
;

7 8
[ 	
Route	 
( 
$str 
) 
] 
public 
IActionResult "
HandleErrorDevelopment 3
(3 4
[ 
FromServices 
] 
IHostEnvironment +
hostEnviroment, :
): ;
{ 	
if 
( 
! 

ModelState 
. 
IsValid #
)# $
{ 
return 

BadRequest !
(! "

ModelState" ,
), -
;- .
} 
if 
( 
! 
hostEnviroment 
.  
IsDevelopment  -
(- .
). /
)/ 0
{ 
return 
NotFound 
(  
)  !
;! "
} 
var '
exceptionHandlerPathFeature +
=, -
HttpContext. 9
.9 :
Features: B
.B C
GetC F
<F G(
IExceptionHandlerPathFeatureG c
>c d
(d e
)e f
;f g
return 
Problem 
( 
detail 
: '
exceptionHandlerPathFeature 3
.3 4
Error4 9
.9 :

StackTrace: D
,D E
title 
: '
exceptionHandlerPathFeature 2
.2 3
Error3 8
.8 9
Message9 @
) 
; 
} 	
} 
}   ¢
xC:\Users\ifspn\OneDrive\Desktop\APPS\backend-portal-sv\backend-portal-sv\backend-portal-sv\Controllers\AuthController.cs
	namespace 	
backend_portal_sv
 
. 
Controllers '
{ 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
) 
] 
[ 
Produces 
( 
$str  
)  !
]! "
[ 
Tags 	
(	 

$str
 
) 
] 
public 

class 
AuthController 
:  !
ControllerBase" 0
{ 
private 
readonly 
ITokenService &
_tokenService' 4
;4 5
public 
AuthController 
( 
ITokenService +
tokenService, 8
)8 9
{ 	
_tokenService 
= 
tokenService (
;( )
} 	
[## 	
HttpPost##	 
]## 
[$$ 	 
ProducesResponseType$$	 
($$ 
StatusCodes$$ )
.$$) *
Status200OK$$* 5
)$$5 6
]$$6 7
[%% 	 
ProducesResponseType%%	 
(%% 
StatusCodes%% )
.%%) *
Status400BadRequest%%* =
)%%= >
]%%> ?
public&& 
async&& 
Task&& 
<&& 
IActionResult&& '
>&&' (
Auth&&) -
(&&- .
[&&. /
FromBody&&/ 7
]&&7 8
LoginRequest&&9 E
request&&F M
)&&M N
{'' 	
if(( 
((( 
request(( 
.(( 
Email(( 
==((  
$str((! 2
&&((3 5
request((6 =
.((= >
Password((> F
==((G I
$str((J Q
)((Q R
{)) 
var** 
token** 
=** 
await** !
_tokenService**" /
.**/ 0
GenerateToken**0 =
(**= >
)**> ?
;**? @
return++ 
Ok++ 
(++ 
new++ 
{++ 
token++  %
}++& '
)++' (
;++( )
},, 
return00 

BadRequest00 
(00 
$str00 ;
)00; <
;00< =
}11 	
}22 
}33 