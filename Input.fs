module AoC.Input

open System
open System.IO
open System.Net.Http

let private findRepoRoot () =
    let rec loop current =
        if File.Exists(Path.Combine(current, "AoC.sln")) then
            current
        else
            let parent = DirectoryInfo(current).Parent
            if isNull parent then
                current
            else
                loop parent.FullName

    loop (Directory.GetCurrentDirectory())

let private repoRoot =
    let root = findRepoRoot ()
    if String.IsNullOrWhiteSpace(root) then
        Directory.GetCurrentDirectory()
    else
        root

let private getLocalInputPath year day =
    Path.Combine(repoRoot, year.ToString(), "input", sprintf "Day%02i" day, "input.txt")

let readLines year day =
    let localPath = getLocalInputPath year day

    if File.Exists(localPath) then
        File.ReadAllLines(localPath)
    else
        let session = Environment.GetEnvironmentVariable("AOC_SESSION")

        if String.IsNullOrWhiteSpace(session) then
            failwith $"Input file not found at '{localPath}' and AOC_SESSION is not set."

        let client = new HttpClient()
        client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0")
        client.DefaultRequestHeaders.Add("Cookie", $"session={session}")

        let url = $"https://adventofcode.com/{year}/day/{day}/input"
        let response = client.GetStringAsync(url).Result.TrimEnd()

        let directory = Path.GetDirectoryName(localPath)
        if not (String.IsNullOrWhiteSpace(directory)) then
            Directory.CreateDirectory(directory) |> ignore

        File.WriteAllText(localPath, response)
        response.Split([| "\r\n"; "\n" |], StringSplitOptions.None)
