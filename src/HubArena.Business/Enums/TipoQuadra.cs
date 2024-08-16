namespace HubArena.Business.Enums
{
    [Flags]
    public enum TipoQuadra
    {
        None = 0,
        Aberta = 1,
        Fechada = 1<<1,
        Poliesportiva = 1<<2,
        Sintética = 1<<3,
        GramaNatural = 1<<4,
        Areia = 1<<5,
        Madeira = 1<<6,
        Acrílica = 1<<7,
        Concreto = 1<<8,

        //0,1,2,4,8,16,32,64,128,256
        
    }
}
