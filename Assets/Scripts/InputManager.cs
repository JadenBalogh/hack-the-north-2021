using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    InputField inputField;

    private string matchingString = "";

    private string lastString = "";

    private string customString = "";

    public List<GameObject> textElements;

    private string[,] wordLists = new string[4, 570]
    {
        {"season","remaining","giant","package","objective","director","massive","early","troop","cloud","instead","commit","account","latter","distant","expression","vacation","retire","kitchen","dinner","stuff","united","little","clothes","require","taste","ticket","furniture","ceremony","muscle","truly","approval","orientation","follow","approach","increasingly","terrorist","peace","curriculum","tragedy","apple","analyze","encounter","sudden","cross","being","series","depending","profession","entry","disaster","delivery","surprisingly","governor","hotel","chamber","component","occasion","creation","attach","piano","damage","restore","scale","ceiling","calculate","travel","should","express","authority","former","ensure","touch","employment","trial","technical","physical","industrial","admire","complete","clear","invite","famous","taxpayer","missile","advantage","permission","summer","justify","occupy","protection","rapidly","marketing","search","trade","engage","translate","reach","straight","celebration","enter","classroom","spokesman","factory","primary","japanese","league","expense","colonial","publication","attempt","intend","among","comfortable","disease","framework","think","experiment","incident","remote","stage","iraqi","leave","totally","agency","historian","separate","shout","raise","commercial","cycle","proposal","decline","grand","represent","confusion","power","segment","print","representative","benefit","session","total","exercise","pollution","button","weight","improve","decide","constitute","intelligence","dealer","trust","possible","formula","shade","initially","abortion","safety","structure","native","slowly","quickly","shopping","smart","serious","shell","survival","twice","pilot","contrast","sweep","supposed","offer","canadian","clean","exhibition","effective","before","establishment","fashion","product","wound","movement","nuclear","encourage","introduce","silver","noise","urban","hunting","success","proceed","silence","official","photo","cancer","middle","reform","participate","spending","particularly","absorb","sector","belief","regulation","carefully","recovery","institutional","handle","concentration","match","attack","radical","loose","sequence","probably","dozen","master","effectively","proportion","yourself","visitor","welfare","react","carbon","corporation","honest","frequently","absolute","actress","return","medical","animal","world","group","worried","stare","sleep","irish","effect","helpful","typically","defeat","radio","regarding","everywhere","narrow","officer","invest","thing","regularly","historic","virtually","dominate","educator","scenario","invasion","emission","color","indication","person","sample","regardless","another","differently","switch","vulnerable","cooking","explore","common","witness","crash","perhaps","broken","bring","lovely","essay","growing","software","compose","progress","emergency","propose","single","pause","audience","origin","supporter","wealth","interpretation","stranger","definition","alliance","stair","exposure","athletic","submit","nation","strike","handful","ethnic","brand","stress","journalist","satisfaction","money","private","piece","headquarters","enough","plastic","singer","creative","steel","recent","mention","electric","brilliant","myself","constantly","curious","reflection","command","literary","version","standing","beautiful","cheap","prominent","horizon","voice","stand","consequence","matter","forest","property","shirt","inside","advocate","float","event","depression","immigration","absence","wonder","active","reaction","latin","presentation","extremely","strong","important","except","battle","appreciate","process","precisely","whole","portion","sales","strongly","personal","coffee","greatest","circle","although","collapse","running","alone","increased","dining","painting","mixture","violate","annual","manage","internal","grain","sweet","publish","front","lesson","shift","train","reinforce","media","client","reasonable","recommend","locate","staff","supply","bother","guarantee","clinic","strategy","recipe","until","elect","nurse","investment","daughter","article","miracle","corner","philosophy","teaspoon","writer","permit","killer","thinking","phone","confirm","proud","prisoner","blind","shore","fifth","heaven","permanent","argument","tomato","genetic","recover","conservative","demonstration","northern","according","uniform","result","brick","physician","breath","metal","national","religion","british","relax","health","really","arrangement","academic","gently","embrace","avoid","shadow","custom","international","address","network","military","seize","evaluation","overcome","leading","ignore","recognition","resident","importance","transform","tired","employer","freedom","colleague","provision","offensive","procedure","motor","indian","incorporate","lunch","usually","mount","prompt","people","accident","listen","tongue","never","develop","publicly","afternoon","anxiety","throw","growth","comprehensive","steal","enforcement","tablespoon","shake","recruit","nothing","eventually","drama","learning","responsibility","contribute","approximately","refer","rhythm","aside","sense","which","throughout","girlfriend","class","culture","change","council","resist","scholarship","garlic","initiative","fewer","widespread","below","discussion","exhibit","musical","fiber","lifetime","frequency","narrative","blame","announce","summit","associate","intensity","limited","reveal","danger","adapt","standard","particular","traditional","formal","senate","price","monitor","afford","advice","compete","scheme","hundred","technology","laboratory","score","venture","settle","vegetable","headline","smooth","dress","reflect","photographer","beauty","educational","worker","representation","equipment","block","draft","mystery","acknowledge","adviser","vessel","respondent","final","strange"},
        {"civil","classic","observation","direct","physically","reject","universe","resemble","worth","strip","basketball","thousand","escape","survey","controversy","temperature","beginning","deliver","personnel","extreme","conference","congress","vehicle","become","judgment","golden","behavior","forth","install","whisper","research","jacket","revenue","theater","swing","solar","twenty","tomorrow","conviction","frame","evidence","poetry","medium","remain","country","meaning","include","answer","global","connection","anyway","eastern","potentially","reading","share","laugh","asleep","numerous","action","conventional","advance","customer","illustrate","believe","freeze","future","motivation","slight","eliminate","protect","settlement","capital","amount","forever","stomach","license","definitely","simple","different","territory","decade","always","basket","platform","advertising","testimony","talent","shower","treatment","market","chart","angry","controversial","round","establish","adventure","learn","gallery","federal","count","institution","produce","expand","employee","flame","democratic","valuable","clock","present","surface","receive","center","target","variation","various","extraordinary","musician","symptom","commander","uncle","barely","minority","chase","apartment","membership","administration","asset","understanding","sacred","predict","credit","horse","distribute","imply","height","portray","concerned","status","north","insist","debate","destroy","field","highlight","evening","currently","interview","coalition","decrease","attend","democrat","friendship","sight","plenty","resistance","unfortunately","obviously","earnings","estimate","virtue","entire","prison","juice","finally","immediately","repeat","divide","surprise","organize","landscape","efficiency","meanwhile","ahead","nonetheless","critic","description","profit","boundary","presence","closely","somewhere","likely","instructor","relate","lover","start","slightly","fabric","therefore","prior","background","knife","obligation","following","political","economic","southern","extension","sport","manufacturing","branch","label","sorry","paper","committee","charity","tonight","succeed","exact","testify","regime","example","statement","ongoing","memory","reduction","cognitive","complicated","leather","intention","panel","player","expensive","sufficient","judge","principal","throat","foreign","transition","chocolate","unable","location","instance","survivor","river","necessarily","flesh","brain","similarly","politically","provider","toward","energy","sensitive","author","qualify","lemon","downtown","athlete","bedroom","rural","smell","column","impose","circumstance","entrance","including","route","candidate","maker","additional","compare","adult","grandmother","electronic","accomplish","population","operator","proof","suggest","youth","tissue","dance","soldier","recall","mayor","mexican","racial","independent","analyst","constant","penalty","pepper","union","south","available","congressional","convention","faith","birth","hungry","through","remarkable","church","wedding","exceed","smile","direction","mostly","achieve","legitimate","saving","practice","access","billion","funny","barrel","image","abuse","business","somebody","tunnel","combination","violent","pride","investigator","attribute","substance","quick","thank","construct","reporter","exactly","everybody","solution","choose","section","ancient","educate","camera","threat","volume","career","doctor","victim","composition","bathroom","anybody","surround","salad","spread","psychological","forget","cigarette","fourth","weekend","sister","guide","distinguish","tactic","company","majority","truth","shine","expect","assess","violence","implement","angle","regional","demonstrate","significantly","specialist","visible","extend","found","bombing","terms","successfully","highly","security","woman","investor","legacy","birthday","belong","communication","participation","french","chief","along","admit","assist","threaten","strategic","above","unique","these","protest","party","ability","resolve","thick","attorney","accompany","distinction","living","ground","habit","dominant","practical","largely","characterize","decision","gradually","criteria","finish","course","continued","table","plant","court","grass","suffer","contain","recognize","ghost","breakfast","regular","anymore","solve","check","highway","green","upper","pattern","punishment","however","garage","visit","perfectly","painter","about","illness","concrete","whose","government","primarily","consumption","powder","twelve","accuse","alternative","subsequent","episode","engine","married","emotional","brown","criticize","novel","maybe","ocean","requirement","complex","cookie","extra","addition","several","versus","flight","involved","purpose","pretty","notice","depict","frustration","introduction","thanks","islamic","fighting","economics","darkness","christian","perfect","priority","jewish","explode","fault","subject","scholar","tournament","assistance","climb","apart","therapy","publisher","pound","acquire","store","developing","condition","professional","adjust","refuse","responsible","identify","length","application","often","prove","heart","lawyer","undergo","detect","offense","involve","newspaper","infant","generate","furthermore","create","beneath","insight","convince","powerful","exist","anywhere","budget","county","boyfriend","careful","today","vision","actually","strength","rifle","increasing","chair","flower","cholesterol","relevant","principle","elderly","build","glance","inquiry","chance","adjustment","hello","pretend","equally","human","ethics","support","museum","regulate","unlike","priest","scared","itself","initial","organic","influence","drink","badly","innocent","chemical","figure","pitch","usual","shock","internet","fence","victory","administrator","generation","online","choice","depth"},
        {"public","production","joint","development","employ","champion","retirement","lawsuit","could","captain","challenge","immigrant","themselves","wrong","difficult","fitness","atmosphere","signal","relative","biological","divorce","relief","attractive","content","diverse","write","spanish","baseball","better","around","value","already","obtain","celebrate","presidential","ought","window","shoot","accept","still","brief","relationship","criticism","broad","track","domestic","spend","imagine","stream","reduce","grant","friendly","assignment","destruction","appointment","deputy","their","funding","rapid","white","aircraft","waste","editor","spring","soviet","struggle","scope","contact","sophisticated","degree","actual","empty","occupation","eager","gifted","glove","assert","marriage","library","finger","oppose","ordinary","conversation","region","terrible","counselor","without","founder","accurate","retain","quite","strengthen","apparent","storage","message","husband","entirely","warning","unknown","between","scandal","system","quiet","local","galaxy","anniversary","elsewhere","expansion","either","identification","illegal","super","alter","heritage","shortly","russian","activity","eight","assume","chinese","since","inflation","gentleman","script","basically","surgery","month","patch","central","paint","democracy","winner","producer","review","member","wheel","revolution","feature","earth","consensus","differ","small","normal","given","executive","tribe","speak","heavy","describe","mental","weather","besides","enormous","watch","light","measure","surely","flavor","bottle","actor","persuade","prime","disorder","honey","charge","board","exciting","winter","other","climate","explosion","italian","consideration","yellow","consider","performance","feeling","wisdom","industry","english","neither","policy","current","excellent","symbol","normally","battery","enable","contract","general","widely","convert","reservation","music","discourse","hearing","behind","shoulder","division","conduct","wonderful","impressive","writing","contemporary","multiple","aware","extensive","reference","porch","restaurant","historical","implication","letter","force","perspective","preserve","desperate","reply","grave","certain","launch","competitive","consumer","positive","previously","professor","workshop","adolescent","communicate","suggestion","element","refugee","concert","finance","tradition","experience","interesting","fortune","characteristic","driver","tobacco","agricultural","foundation","speed","first","journal","nervous","neighborhood","double","explanation","function","specific","construction","dirty","inspire","healthy","recommendation","false","comedy","armed","expectation","cluster","document","might","chairman","chest","capable","cover","fight","indeed","emphasize","imagination","agreement","welcome","literature","pocket","supreme","weigh","tennis","stick","release","cotton","gender","context","slide","poverty","holiday","margin","complain","constitutional","sexual","crazy","cabinet","serve","remove","replace","devote","basis","sauce","select","junior","model","situation","nowhere","material","appropriate","corporate","question","knowledge","fifteen","mainly","family","politician","correspondent","century","mistake","arrive","spirit","willing","aggressive","breathe","moreover","amazing","phase","realize","against","there","despite","design","senator","tooth","evaluate","connect","appear","position","fundamental","movie","marry","resort","working","guideline","information","discrimination","negotiation","favorite","species","limitation","quarter","unlikely","enterprise","works","station","desire","mother","quote","right","properly","manner","original","tough","others","plane","management","detail","because","murder","disability","planet","distance","square","beyond","beside","asian","night","district","would","nevertheless","killing","pressure","drawing","ready","observe","picture","pregnant","agree","efficient","maintain","critical","journey","mountain","dramatic","garden","though","relation","brother","religious","viewer","yield","truck","frequent","combine","edition","recently","regard","utility","awful","examination","severe","school","appeal","afraid","opponent","expose","program","response","method","commission","profile","weapon","relatively","award","anticipate","cheese","economist","least","anything","explain","tight","housing","partnership","indicate","parking","nomination","negative","certainly","estate","worry","comparison","cause","mortgage","literally","exception","later","large","essentially","defensive","possibility","resource","silent","happy","testing","abandon","slave","something","proposed","barrier","rather","clothing","collect","perceive","thirty","western","morning","carry","arrival","channel","discovery","happen","seriously","funeral","everything","leader","attitude","chain","coach","partner","legislation","nerve","existence","female","secret","digital","affect","generally","investigate","friend","interested","finding","treaty","mutual","dialogue","facility","street","adopt","psychologist","intense","squeeze","considerable","sugar","blood","college","passion","hardly","tension","architect","previous","split","error","scene","understand","affair","routine","secure","contribution","department","delay","directly","telescope","complaint","magazine","visual","opening","whatever","impact","nature","transportation","bottom","craft","especially","privacy","bench","transformation","campus","operating","recording","instruction","citizen","planning","ultimate","storm","reality","originally","injury","prosecutor","guess","overall","towards","please","surprising","minister","yesterday","beach","fresh","stock","unusual","conclude","theme","disagree","negotiate","phenomenon","impress","continue","great","enjoy","merely","limit","dream","hospital","agent","state"},
        {"somewhat","external","history","airline","olympic","assessment","opinion","expert","useful","space","computer","immediate","inner","prospect","graduate","control","shelf","personally","teacher","ideal","extent","speech","three","bullet","terror","dimension","conflict","stake","opposite","device","essential","teaching","statistics","difficulty","scream","consultant","incredible","almost","range","fighter","manager","yours","somehow","senior","arrange","engineer","meter","valley","gather","topic","perception","survive","potato","effort","mirror","modest","consciousness","whereas","onion","second","smoke","patient","portrait","natural","purchase","sound","promise","outside","album","lower","glass","investigation","child","coast","reputation","option","outcome","republican","object","provide","breast","labor","fellow","prayer","nearby","counter","childhood","palestinian","anyone","every","analysis","emphasis","repeatedly","possibly","category","significance","sentence","cheek","individual","while","distinct","water","someone","student","comfort","screen","shape","argue","depend","assistant","airport","detailed","failure","rating","border","balance","researcher","source","proper","discover","operate","infection","admission","shall","brush","successful","wooden","couch","concept","traffic","nearly","guest","shooting","consistent","whether","pleasure","universal","basic","claim","cabin","disappear","alcohol","guilty","bunch","slice","legend","arrest","ratio","bread","focus","plate","moderate","community","sustain","defense","blanket","achievement","african","bright","pursue","deserve","artistic","dispute","index","minute","clinical","partly","personality","discuss","assure","confident","million","wander","honor","incentive","building","fruit","major","moment","secretary","phrase","resolution","after","medicine","bridge","pregnancy","title","forward","dramatically","doubt","reason","distribution","capacity","allow","terrorism","fishing","fantasy","those","income","bible","awareness","blade","catholic","herself","enemy","enhance","psychology","register","attract","drive","championship","intervention","agenda","wealthy","selection","consist","passenger","economy","inform","technique","fiction","language","order","police","stone","tourist","clearly","advise","buyer","obvious","payment","emerge","crucial","meeting","cable","respect","potential","impression","seven","virus","couple","painful","humor","contest","withdraw","abroad","discipline","shrug","report","speaker","tower","mouse","activist","treat","impossible","derive","himself","substantial","instrument","apparently","adequate","owner","simply","cream","catch","difference","stupid","commitment","approve","violation","demand","collection","village","weekly","overlook","confidence","average","identity","existing","association","under","politics","percentage","reader","horror","artist","prefer","request","leadership","begin","celebrity","transfer","where","together","creature","place","financial","skill","sharp","during","province","setting","story","mechanism","soccer","declare","fifty","roughly","attention","press","nobody","carrier","intellectual","typical","perform","crack","problem","comment","newly","trend","death","rough","quality","cultural","appoint","ingredient","lifestyle","improvement","determine","everyday","defendant","israeli","mouth","confront","grandfather","insurance","mission","interest","level","consume","opportunity","point","american","advanced","assault","across","occasionally","helicopter","participant","criminal","significant","satisfy","elite","evolve","factor","video","capture","organization","legal","necessary","campaign","romantic","office","maintenance","suicide","restriction","competitor","respond","civilian","style","increase","examine","island","hypothesis","orange","anger","rarely","opposition","shelter","parent","german","father","specifically","household","veteran","concentrate","fully","remember","desert","whenever","again","swear","briefly","number","european","scientific","aspect","stretch","study","favor","manufacturer","science","absolutely","otherwise","trouble","tendency","faculty","steady","conclusion","observer","prevent","butter","daily","solid","modern","quarterback","prepare","apply","grocery","entertainment","suppose","issue","measurement","borrow","sheet","equal","president","special","variety","preference","engineering","easily","changing","environment","naked","stroke","teenager","prescription","motion","schedule","record","thought","justice","temporary","gesture","dependent","coverage","period","alive","operation","television","project","third","knock","capability","tremendous","heavily","protein","medication","possess","dangerous","makeup","habitat","exchange","social","moral","assign","concern","vital","young","defend","crowd","neighbor","break","telephone","football","electricity","service","notion","assumption","display","ultimately","crime","passage","surprised","guard","minor","university","cousin","chicken","interaction","training","hunter","salary","diversity","unless","liberal","volunteer","education","environmental","designer","formation","suddenly","layer","crisis","independence","scientist","emotion","evolution","everyone","machine","remind","completely","similar","courage","grade","correct","appearance","sanction","naturally","variable","competition","muslim","collective","closer","promote","trail","teach","occur","trace","homeless","string","chapter","studio","society","ourselves","theory","satellite","lucky","voter","quietly","deeply","floor","within","house","election","container","character","arise","cooperation","trick","stable","dismiss","close","stability","interpret","farmer","spiritual","popular","christmas","burden","elementary","preparation","familiar","photograph","sometimes","fairly","suspect","black","involvement"}
    };

    public string[] wordList;

    public delegate void ActionCallback();

    public List<ActionCallback> callbacks = new List<ActionCallback>() { PlaceholderCallbacks.Callback1, PlaceholderCallbacks.Callback2, PlaceholderCallbacks.Callback3, PlaceholderCallbacks.Callback4 };

    void Start()
    {
        wordList = new string[4] { wordLists[0, 0], wordLists[1, 0], wordLists[2, 0], wordLists[3, 0] };

        inputField = GetComponentInChildren<InputField>();
        inputField.Select();
        inputField.ActivateInputField();
        ResetTextDisplays();
    }

    public void ReadInput(string myStr)
    {
        // On escape key pressed, reset everything
        if (myStr == "")
        {
            matchingString = "";
            lastString = "";
            customString = "";
            ResetTextDisplays();
            inputField.Select();
            inputField.ActivateInputField();
            return;
        }

        // If user is hitting backspace, ignore that input
        if (lastString.Length > myStr.Length)
        {
            lastString = myStr;
            return;
        }

        customString += myStr[myStr.Length - 1];

        char lastTyped = customString[customString.Length - 1];
        matchingString += lastTyped;

        bool noMatch = true;

        for (int i = 0; i < textElements.Count; i++)
        {
            string currentWord = wordList[i];
            if (matchingString.Length <= currentWord.Length && matchingString == currentWord.Substring(0, matchingString.Length))
            {
                noMatch = false;

                if (matchingString == currentWord)
                {
                    wordList[i] = wordLists[i, Random.Range(0, wordLists.GetLength(1))];
                    callbacks[i]();
                    matchingString = "";
                    ResetTextDisplays();
                }
                else
                {
                    string moreGreen = GetStringWithGreenUpTo(currentWord, matchingString.Length);
                    textElements[i].GetComponent<Text>().text = moreGreen;
                }
            }
        }

        if (noMatch)
        {
            matchingString = matchingString.Substring(0, matchingString.Length - 1);
        }

        lastString = myStr;
    }

    void ResetTextDisplays()
    {
        for (int i = 0; i < textElements.Count; i++)
        {
            textElements[i].GetComponent<Text>().text = wordList[i];
        }

    }

    string GetStringWithGreenUpTo(string input, int max)
    {
        string result = "<color=green>";
        result += input.Substring(0, max);
        result += "</color>";
        result += input.Substring(max);
        return result;
    }
}
