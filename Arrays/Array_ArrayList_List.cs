using System.Collections;

namespace Arrays;

/// <summary>
/// Questão 1: demonstra as principais diferenças entre <see cref="Array"/>,
/// <see cref="ArrayList"/> e <see cref="List{T}"/>.
/// </summary>
/// <remarks>
/// <para><b>Array:</b> tamanho fixo, tipagem forte, acesso O(1) e baixo overhead.</para>
/// <para><b>ArrayList:</b> tamanho dinâmico, mas sem tipagem genérica; tipos de valor sofrem boxing e unboxing.</para>
/// <para><b>List&lt;T&gt;:</b> tamanho dinâmico, tipagem forte e acesso O(1) por índice.</para>
/// </remarks>
public sealed class Array_ArrayList_List
{
    public int[] Array { get; } = new[] { 1, 2, 3 };

    // Aceita elementos de tipos diferentes e, portanto, não oferece segurança de tipos.
    public ArrayList NonGenericList { get; } = new() { 1, "hello" };

    public List<int> GenericList { get; } = new() { 1, 2, 3 };
}
