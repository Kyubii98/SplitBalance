using Microsoft.JSInterop;
using Supabase.Gotrue;
using Newtonsoft.Json;

namespace Balance.Services
{
    public class SupabaseSessionHandler : Supabase.Gotrue.Interfaces.IGotrueSessionPersistence<Session>
    {
        private readonly IJSInProcessRuntime _runtime;

        public SupabaseSessionHandler(IJSRuntime runtime)
        {
            _runtime = (IJSInProcessRuntime)runtime;
        }

        public void DestroySession()
        {
            _runtime.InvokeVoid("localStorage.removeItem", "supabase.session");
        }

        public Session? LoadSession()
        {
            var json = _runtime.Invoke<string?>("localStorage.getItem", "supabase.session");

            if (string.IsNullOrEmpty(json)) return null;
            return JsonConvert.DeserializeObject<Session>(json);
        }

        public void SaveSession(Session session)
        {
            var json = JsonConvert.SerializeObject(session);
            _runtime.InvokeVoid("localStorage.setItem", "supabase.session", json);
        }
    }
}