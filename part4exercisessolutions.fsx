#r "System.Xml.Linq" 
#r "packages/FSharp.Data/lib/net40/FSharp.Data.dll" 
#r "System.Xml.Linq.dll"
open FSharp.Data

type Rss = XmlProvider<"https://www.theguardian.com/world/rss">

let sample = Rss.GetSample ()

for item in sample.Channel.Items do
    printfn "%s" item.Title

