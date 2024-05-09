using System.Text.Json;
using ScreenSound;
using ScreenSound.Filtros;

using (HttpClient cliente = new HttpClient())
{
    try
    {
        string resposta = await cliente.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;
        // LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
        // LinqOrder.ExibirListaDeArtistasOrdenados(musicas);
        // LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "pop");
        // LinqFilter.FiltrarMusicasDeUmArtista(musicas, "U2");
        var musicasPreferidasDoVinicius = new MusicasPreferidas("Daniel");
        musicasPreferidasDoVinicius.AdicionarMusicasFavoritas(musicas[1]);
        musicasPreferidasDoVinicius.AdicionarMusicasFavoritas(musicas[6]);
        musicasPreferidasDoVinicius.AdicionarMusicasFavoritas(musicas[9]);
        musicasPreferidasDoVinicius.AdicionarMusicasFavoritas(musicas[15]);
        musicasPreferidasDoVinicius.AdicionarMusicasFavoritas(musicas[71]);

        musicasPreferidasDoVinicius.ExibirMusicasFavoritas();
        musicasPreferidasDoVinicius.GerarArquivoJson();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}