[HttpGet]
public async Task<IActionResult> GetAll()
{
    var ativos = await _repo.GetAllAsync();
    var dtos = ativos.Select(a => new AtivoReadDto {
        Id = a.Id,
        Codigo = a.Codigo,
        Nome = a.Nome
    });
    return Ok(dtos);
}
