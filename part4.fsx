#r "System.Xml.Linq" 
#r "packages/FSharp.Data/lib/net40/FSharp.Data.dll" 
#r "System.Xml.Linq.dll"
#load "packages/FSharp.Charting/FSharp.Charting.fsx"
open FSharp.Charting
open FSharp.Data

module WB =
    let data = WorldBankData.GetDataContext()

    data.Countries.Norway.Indicators.``Agricultural machinery, tractors per 100 sq. km of arable land`` |> Chart.Line

    data.Countries.Norway.Indicators.``GDP per capita (constant 2010 US$)`` |> Chart.Line

module JsonStuff =
    let [<Literal>] sample = """ 
{
    "glossary": {
        "title": "example glossary",
		"GlossDiv": {
            "title": "S",
			"GlossList": {
                "GlossEntry": {
                    "ID": "SGML",
					"SortAs": "SGML",
					"GlossTerm": "Standard Generalized Markup Language",
					"Acronym": "SGML",
					"Abbrev": "ISO 8879:1986",
					"GlossDef": {
                        "para": "A meta-markup language, used to create markup languages such as DocBook.",
						"GlossSeeAlso": ["GML", "XML"]
                    },
					"GlossSee": "markup"
                }
            }
        }
    }
}    
    
    """
    type Provider1 = JsonProvider<sample>
    let value = Provider1.GetSample ()
    value.Glossary.GlossDiv.GlossList.GlossEntry.Id
    
    
    type ProviderPeople = JsonProvider<""" 
        [ { "name":"John", "age":94 }, 
            { "name":"Tomas" } ] """>

    let loaded = ProviderPeople.Load "example.json"

    for p in loaded do
        match p.Age with
        | Some age -> printfn "%s is %d years old" p.Name age
        | None -> printfn "We don't know %s age" p.Name

// ---------------------------------------------------------------
//         EXERCISES
// ---------------------------------------------------------------

// Play with WorldBankData. Try to add titles and descriptions to the plot. Try to plot multiple lines on a single plot. 

// FSharp.Data provides also XmlTypeProvider. Try to use it to read some RSS feed, e.g. The Guardian https://www.theguardian.com/world/rss

