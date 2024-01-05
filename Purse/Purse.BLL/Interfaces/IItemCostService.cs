using Purse.BLL.DTO.CostItem;

namespace Purse.BLL.Interfaces
{
    public interface IItemCostService
    {
        public Task<CostItemDTO> CreateCostItem(CostItemDTO costItemDto);
	}
}
