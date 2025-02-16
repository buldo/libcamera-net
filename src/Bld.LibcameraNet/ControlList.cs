using System.Collections;
using System.Numerics;
using System.Runtime.CompilerServices;
using Bld.LibcameraNet.Controls;
using Bld.LibcameraNet.Interop.Libcamera;

namespace Bld.LibcameraNet;

public class ControlList<TId> where TId : struct, Enum
{
    private readonly IntPtr _listPtr;

    private Dictionary<TId, ControlValue<TId>> _controls;

    internal ControlList(IntPtr listPtr)
    {
        _listPtr = listPtr;
        Reload();
    }

    public void Reload()
    {
        var definitionsList = new ControlListInternal<TId>(_listPtr);
        _controls = definitionsList
            .Select(ControlValueFactory<TId>.Create)
            .ToDictionary(value => value.Id);
    }

    public ControlValue<TId>? Get(TId id)
    {
        return _controls.GetValueOrDefault(id);
    }

    //public T? Get<T>() where T : class, IProperty<T>
    //{
    //    var val = _values.FirstOrDefault(value => value.Id == (nuint)T.Id);
    //    IntPtr controlPtr;
    //    if (val == null)
    //    {
    //        controlPtr = LibcameraNative.ControlListGet(_list.GetPtr(), (int)T.Id);
    //        if (controlPtr == IntPtr.Zero)
    //        {
    //            return null;
    //        }
    //    }
    //    else
    //    {
    //        controlPtr = val.ValuePtr;
    //    }

    //    var ty = LibcameraNative.ControlValueType(controlPtr);
    //    var numElements = LibcameraNative.ControlValueNumElements(controlPtr);
    //    var data = LibcameraNative.ControlValueGet(controlPtr);

    //    return T.Create(ty, (int)numElements, data);
    //}

    internal IntPtr GetPtr()
    {
        return _listPtr;
    }

    #region Iterator
    private class ControlListInternal<TId>
        : IEnumerable<ControlValueDefinition<TId>> where TId: Enum
    {
        private readonly IntPtr _listPtr;

        public ControlListInternal(IntPtr listPtr)
        {
            _listPtr = listPtr;
        }

        public IEnumerator<ControlValueDefinition<TId>> GetEnumerator()
        {
            var listIteratorPtr = LibcameraNative.ControlListIter(_listPtr);
            return new ControlListInternalEnumerator<TId>(listIteratorPtr);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal IntPtr GetPtr()
        {
            return _listPtr;
        }
    }

    private class ControlListInternalEnumerator<TId>
        : IEnumerator<ControlValueDefinition<TId>> where TId : Enum
    {
        private readonly IntPtr _iteratorPtr;
        private bool _isFirstElement = true;

        public ControlListInternalEnumerator(IntPtr iteratorPtr)
        {
            _iteratorPtr = iteratorPtr;
        }

        public bool MoveNext()
        {
            if (LibcameraNative.ControlListIterEnd(_iteratorPtr))
            {
                return false;
            }

            if (!_isFirstElement)
            {
                LibcameraNative.ControlListIterNext(_iteratorPtr);
                _isFirstElement = false;
            }

            Current = CreateCurrent();

            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public ControlValueDefinition<TId> Current { get; private set;}

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
            LibcameraNative.ControlListIterDestroy(_iteratorPtr);
        }

        private ControlValueDefinition<TId> CreateCurrent()
        {
            var idValue = (int)LibcameraNative.ControlListIterId(_iteratorPtr);
            var id = Unsafe.As<int, TId>(ref idValue);
            var valuePtr = LibcameraNative.ControlListIterValue(_iteratorPtr);
            return new ControlValueDefinition<TId>(id, valuePtr);
        }
    }
    #endregion
}

