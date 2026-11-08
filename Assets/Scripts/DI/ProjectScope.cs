using Analyzer.Managers;
using VContainer;
using VContainer.Unity;

namespace Analyzer.DI
{
    public class ProjectScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            //Managers
            builder.RegisterEntryPoint<GamesManager>().AsSelf();
        }
    }
}